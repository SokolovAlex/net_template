using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace App.Generator
{
    public partial class GeneratorForm : Form
    {
        private string _solutionFolder = ConfigurationManager.AppSettings["LastSolutionFolder"];
        private readonly string _templatesFolder = ConfigurationManager.AppSettings["TemplatesFolder"];
        private readonly List<string> _installedModules = new List<string>();

        public GeneratorForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void btGenerate_Click(object sender, EventArgs e)
        {
            //var moduleName = "Article";
            //var modelName = "ArticleComment";

            var moduleName = cbModuleList.SelectedItem.ToString();
            var modelName = tbModelName.Text;

            try
            {
                if (!string.IsNullOrWhiteSpace(_solutionFolder) && !string.IsNullOrWhiteSpace(moduleName) && !string.IsNullOrEmpty(modelName))
                {
                    // Add Model
                    var model = File.ReadAllText(Path.Combine(_templatesFolder, "ExampleModel.txt"));
                    SaveToFile(Path.Combine(_solutionFolder, $"App.DTO\\Models\\{moduleName}\\"), $"{modelName}Model.cs", ReplaceInClass(model, moduleName, modelName));

                    // Add Entity
                    var entity = File.ReadAllText(Path.Combine(_templatesFolder, "ExampleEntity.txt"));
                    SaveToFile(Path.Combine(_solutionFolder, $"App.DAL\\Entities\\{moduleName}\\"), $"{modelName}Entity.cs", ReplaceInClass(entity, moduleName, modelName));

                    // Add IRepository
                    var iRepository = File.ReadAllText(Path.Combine(_templatesFolder, "IExampleRepository.txt"));
                    SaveToFile(Path.Combine(_solutionFolder, $"App.DAL\\Abstract\\{moduleName}\\"), $"I{modelName}Repository.cs", ReplaceInClass(iRepository, moduleName, modelName));

                    // Add Repository
                    var repository = File.ReadAllText(Path.Combine(_templatesFolder, "ExampleRepository.txt"));
                    SaveToFile(Path.Combine(_solutionFolder, $"App.DAL\\Concrete\\{moduleName}\\"), $"{modelName}Repository.cs", ReplaceInClass(repository, moduleName, modelName));

                    // Add IManager
                    var iManager = File.ReadAllText(Path.Combine(_templatesFolder, "IExampleManager.txt"));
                    SaveToFile(Path.Combine(_solutionFolder, $"App.BLL\\Abstract\\Managers\\{moduleName}\\"), $"I{modelName}Manager.cs", ReplaceInClass(iManager, moduleName, modelName));

                    // Add Manager
                    var manager = File.ReadAllText(Path.Combine(_templatesFolder, "ExampleManager.txt"));
                    SaveToFile(Path.Combine(_solutionFolder, $"App.BLL\\Concrete\\Managers\\{moduleName}\\"), $"{modelName}Manager.cs", ReplaceInClass(manager, moduleName, modelName));

                    // Edit Context
                    var contextPath = Path.Combine(_solutionFolder, "App.DAL\\DataContext.cs");
                    File.WriteAllText(contextPath, ReplaceInContext(File.ReadAllText(contextPath), moduleName, modelName));

                    // Edit DAL IoC
                    var dalResolverPath = Path.Combine(_solutionFolder, "App.DAL\\DAL_IoCModule.cs");
                    File.WriteAllText(dalResolverPath, ReplaceInResolver(File.ReadAllText(dalResolverPath), moduleName, modelName, "Repository", "DAL"));

                    // Edit BLL IoC
                    var bllResolverPath = Path.Combine(_solutionFolder, "App.BLL\\BLL_IoCModule.cs");
                    File.WriteAllText(bllResolverPath, ReplaceInResolver(File.ReadAllText(bllResolverPath), moduleName, modelName, "Manager", "BLL"));

                    #region Solution

                    // Edit BLL
                    var bllSolutionPath = Path.Combine(_solutionFolder, "App.BLL\\App.BLL.csproj");
                    File.WriteAllText(bllSolutionPath, AddToSolution(File.ReadAllText(bllSolutionPath), $"Abstract\\Managers\\{moduleName}\\I{modelName}Manager.cs"));
                    File.WriteAllText(bllSolutionPath, AddToSolution(File.ReadAllText(bllSolutionPath), $"Concrete\\Managers\\{moduleName}\\{modelName}Manager.cs"));

                    // Edit DAL
                    var dalSolutionPath = Path.Combine(_solutionFolder, "App.DAL\\App.DAL.csproj");
                    File.WriteAllText(dalSolutionPath, AddToSolution(File.ReadAllText(dalSolutionPath), $"Abstract\\{moduleName}\\I{modelName}Repository.cs"));
                    File.WriteAllText(dalSolutionPath, AddToSolution(File.ReadAllText(dalSolutionPath), $"Concrete\\{moduleName}\\{modelName}Repository.cs"));
                    File.WriteAllText(dalSolutionPath, AddToSolution(File.ReadAllText(dalSolutionPath), $"Entities\\{moduleName}\\{modelName}Entity.cs"));

                    // Edit DTO
                    var dtoSolutionPath = Path.Combine(_solutionFolder, "App.DTO\\App.DTO.csproj");
                    File.WriteAllText(dtoSolutionPath, AddToSolution(File.ReadAllText(dtoSolutionPath), $"Models\\{moduleName}\\{modelName}Model.cs"));

                    #endregion

                    lbMessage.Text = $"{modelName} created!";
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception exception)
            {
                lbMessage.Text = exception.Message;
            }
        }

        private void btSelectProject_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.ShowDialog();
                _solutionFolder = dialog.SelectedPath;
                lbProjectFolder.Text = dialog.SelectedPath;
            }

            var configuration = ConfigurationManager.OpenExeConfiguration("App.Generator.exe");
            configuration.AppSettings.Settings["LastSolutionFolder"].Value = _solutionFolder;
            configuration.Save();
        }

        private void SaveToFile(string folder, string fileName, string fileContent)
        {
            Directory.CreateDirectory(folder);
            File.WriteAllText(Path.Combine(folder, fileName), fileContent);
        }

        private string ReplaceInClass(string source, string module, string model)
        {
            var edited = source.Replace("ExampleModule", module);
            edited = edited.Replace("Example", model);

            return edited;
        }

        private string ReplaceInContext(string source, string module, string model)
        {
            var flag = "\r\n        protected override void OnModelCreating";

            // Add namespace
            var space = $"using App.DAL.Entities.{module};";
            var spaceFlag = "\r\nnamespace App.DAL";
            if (!source.Contains(space))
            {
                source = source.Replace(spaceFlag, $"{space}\r\n{spaceFlag}");
            }

            // Add region
            var region = $"\r\n        #region {module}\r\n";
            if (!source.Contains(region))
            {
                var regionTemplate = $"{region}        #endregion\r\n";
                source = source.Replace(flag, regionTemplate + flag);
            }

            // Add entity
            var item = $"{region}        public DbSet<{model}Entity> {model} {{ get; set; }}\r\n";
            source = source.Replace(region, item);

            return source;
        }

        private string ReplaceInResolver(string source, string module, string model, string type, string assembly)
        {
            var flag = "        }\r\n    }\r\n}";

            // Add namespace
            foreach (var inheritance in new List<string> { "Abstract", "Concrete" })
            {
                var space = $"using App.{assembly}.{inheritance}.{module};";
                if (type == "Manager")
                {
                    space = $"using App.{assembly}.{inheritance}.Managers.{module};";
                }

                var spaceFlag = $"\r\nnamespace App.{assembly}";
                if (!source.Contains(space))
                {
                    source = source.Replace(spaceFlag, $"{space}\r\n{spaceFlag}");
                }
            }

            // Add region
            var region = $"\r\n            #region {module}\r\n";
            if (!source.Contains(region))
            {
                var regionTemplate = $"{region}            #endregion\r\n";
                source = source.Replace(flag, regionTemplate + flag);
            }

            // Add entity
            var item = $"{region}            builder.RegisterType<{model}{type}>().As<I{model}{type}>();\r\n";
            source = source.Replace(region, item);

            return source;
        }

        private string AddToSolution(string source, string filePath)
        {
            var item = $"<ItemGroup>\r\n    <Compile Include=\"{filePath}\" />\r\n    <Compile";
            var flag = "<ItemGroup>\r\n    <Compile";
            
            return source.Replace(flag, item);
        }

        private void Initialize()
        {
            var folders = Directory.GetDirectories($"{_solutionFolder}\\App.Web\\Areas");

            foreach (var module in folders.Select(folder => folder.Split('\\').Last()).Where(module => module != "Base"))
            {
                _installedModules.Add(module);
            }

            lbProjectFolder.Text = _solutionFolder;

            foreach (var module in _installedModules)
            {
                clbModuleList.Items.Add(module, false);
                cbModuleList.Items.Add(module);
            }
        }

        private void btRemoveModules_Click(object sender, EventArgs e)
        {
            try
            {
                var modules = clbModuleList.CheckedItems;

                if (modules.Count > 0)
                {
                    foreach (var module in modules)
                    {
                        // App.DTO
                        DeleteFolder($"{_solutionFolder}\\App.DTO\\Models\\{module}\\");
                        DeleteFile($"{_solutionFolder}\\App.DTO\\Enums\\{module}Enums.cs");

                        // Enums

                    }

                    MessageBox.Show(@"Deleted");
                }
                else
                {
                    MessageBox.Show(@"Not selected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void DeleteFolder(string path)
        {
            var directory = new DirectoryInfo(path);
            if (directory.Exists)
            {
                directory.Delete(true);
            }
        }

        private static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
