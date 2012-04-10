using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Services;
using Roslyn.Compilers.CSharp;
using EnvDTE80;
using System.IO;
using System.Text.RegularExpressions;
namespace Modelo.Cliente
{
    class test
    {
        public static string loadblabla(string content)
        {
            var syntaxTree = SyntaxTree.ParseCompilationUnit(content);
            var namespaceName = (UsingStatementSyntax)syntaxTree.
            Root.
            DescendentNodes().
            First(n => n.Kind == SyntaxKind.UsingStatement);
            return namespaceName.GetText();
        }

        string getClassName(SyntaxTree syntaxTree)
        {
            var className = (ClassDeclarationSyntax)syntaxTree.
            Root.
            DescendentNodes().
            First(n => n.Kind == SyntaxKind.ClassDeclaration);
            return className.GetText().Substring(0, className.GetText().IndexOf("{"));
            
        }

        IEnumerable<KeyValuePair<string,string>> getFields(SyntaxTree syntaxTree)
	    {
            foreach (SyntaxNode node in syntaxTree.Root.DescendentNodes())
            {
                if (node is FieldDeclarationSyntax)
                {                    
                    FieldDeclarationSyntax fds = (FieldDeclarationSyntax) node;
                    yield return new KeyValuePair<string, string>(fds.Declaration.Type.PlainName, fds.Declaration.Variables[0].Identifier.ValueText);
                }
            }		    
	    }

        DTE2 GetActiveIDE()
        {
            // Get an instance of the currently running Visual Studio IDE.
            DTE2 dte2;
            dte2 = (DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.10.0");
            return dte2;
        }

        EnvDTE.Project GetProject(string projectName)
        {
            DTE2 dte2 = GetActiveIDE();
            foreach (EnvDTE.Project proj in dte2.Solution.Projects){
                if (proj.Name == projectName)
                {
                    
                    return proj;
                }
            }
            return null;
        }

        IEnumerable<string> GetFilesStartingWith(string startingPath, string startsWith)
        {
            foreach (string f in Directory.GetFiles(startingPath,startsWith+"*.*",SearchOption.AllDirectories)){
                yield return f;
            }
        }
    }
}
