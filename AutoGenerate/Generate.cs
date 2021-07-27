using CodeSmith.Engine;
using SchemaExplorer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoGenerate
{
    public partial class Generate : Form
    {
        public Generate()
        {
            InitializeComponent();
        }

        private void Generate_button_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, string> srcs = new Dictionary<string, string>();
                string AimModelPath, AimRepositoryPath, AimIRepositoryPath, AimServicesPath, AimIServicesPath;
                AimModelPath = new System.IO.DirectoryInfo(Application.StartupPath + "\\..\\..\\..\\Topshelf.Models\\Entities").FullName;
                if (!AimModelPath.EndsWith("\\")) AimModelPath += "\\";
                AimRepositoryPath = new System.IO.DirectoryInfo(Application.StartupPath + "\\..\\..\\..\\Topshelf.Domain\\Repository").FullName;
                if (!AimRepositoryPath.EndsWith("\\")) AimRepositoryPath += "\\";
                AimIRepositoryPath = new System.IO.DirectoryInfo(Application.StartupPath + "\\..\\..\\..\\Topshelf.Domain\\IRepository").FullName;
                if (!AimIRepositoryPath.EndsWith("\\")) AimIRepositoryPath += "\\";
                AimServicesPath = new System.IO.DirectoryInfo(Application.StartupPath + "\\..\\..\\..\\Topshelf.Domain\\Services").FullName;
                if (!AimServicesPath.EndsWith("\\")) AimServicesPath += "\\";
                AimIServicesPath = new System.IO.DirectoryInfo(Application.StartupPath + "\\..\\..\\..\\Topshelf.Domain\\IServices").FullName;
                if (!AimIServicesPath.EndsWith("\\")) AimIServicesPath += "\\";
                srcs.Add("Model", AimModelPath);
                srcs.Add("Repository", AimRepositoryPath);
                srcs.Add("IRepository", AimIRepositoryPath);
                srcs.Add("Services", AimServicesPath);
                srcs.Add("IServices", AimIServicesPath);
                string name = default;
                DatabaseSchema db = default;
                foreach (System.Windows.Forms.Control outctrl in flowLayoutPanel1.Controls)
                {
                    if (outctrl is RadioButton)
                    {
                        if (((RadioButton)outctrl).Checked)
                        {
                            name = outctrl.Text;
                            if (name == "SqlServer")
                                db = new DatabaseSchema(new SqlSchemaProvider(), DataSource_textBox.Text);
                            else if (name == "MySql")
                                db = new DatabaseSchema(new MySQLSchemaProvider(), DataSource_textBox.Text);
                            else if (name == "Oracle")
                                db = new DatabaseSchema(new OracleSchemaProvider(), DataSource_textBox.Text);
                            else
                                db = new DatabaseSchema(new PostgreSQLSchemaProvider(), DataSource_textBox.Text);
                        }
                    }
                }
                if (string.IsNullOrEmpty(Table_textBox.Text))
                {
                    if (DialogResult.OK == MessageBox.Show("批量执行将覆盖原有的文件，确定此方式执行？", "提示", MessageBoxButtons.OKCancel))
                    {
                        //批量生成
                        string templatepath;
                        templatepath = Application.StartupPath + "\\UsingTemplate\\BatchGeneration.cst";
                        CodeTemplateCompiler compiler = new CodeTemplateCompiler(templatepath);
                        compiler.Compile();
                        if (compiler.Errors.Count == 0)
                        {
                            foreach (var src in srcs)
                            {
                                string head = "";
                                string tail = src.Key;
                                if (src.Key.StartsWith("I"))
                                {
                                    head = "I";
                                    tail = src.Key.Substring(1, src.Key.Length - 1);
                                }
                                else if (src.Key.StartsWith("M"))
                                {
                                    tail = "";
                                }
                                CodeTemplate mytemplae = compiler.CreateInstance();
                                mytemplae.SetProperty("SourceDatabase", db);
                                mytemplae.SetProperty("BathTemplate", src.Key);
                                mytemplae.SetProperty("Head", head);
                                mytemplae.SetProperty("Tail", tail);
                                mytemplae.SetProperty("DbType", name);
                                mytemplae.SetProperty("OutputDirectory", src.Value);
                                mytemplae.RenderToString();
                            }
                        }
                    }
                }
                else
                {
                    //指定生成
                    string templatepath;
                    templatepath = Application.StartupPath + "\\UsingTemplate\\SingleGeneration.cst";
                    CodeTemplateCompiler compiler = new CodeTemplateCompiler(templatepath);
                    compiler.Compile();
                    if (compiler.Errors.Count == 0)
                    {
                        foreach (var src in srcs)
                        {
                            string head = "";
                            string tail = src.Key;
                            if (src.Key.StartsWith("I"))
                            {
                                head = "I";
                                tail = src.Key.Substring(1, src.Key.Length - 1);
                            }
                            else if (src.Key.StartsWith("M"))
                            {
                                tail = "";
                            }
                            CodeTemplate mytemplae = compiler.CreateInstance();
                            mytemplae.SetProperty("TableName", Table_textBox.Text);
                            mytemplae.SetProperty("SourceDatabase", db);
                            mytemplae.SetProperty("BathTemplate", src.Key);
                            mytemplae.SetProperty("Head", head);
                            mytemplae.SetProperty("Tail", tail);
                            mytemplae.SetProperty("DbType", name);
                            mytemplae.SetProperty("OutputDirectory", src.Value);
                            mytemplae.RenderToString();
                        }
                    }
                }
                MessageBox.Show("Success!!!!");
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
