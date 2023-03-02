using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApplication

{
    class Program
    {

        static void Main(string[] args)
        {
            List<Task> taskList = new List<Task>(); 

          
            Menu();
            string input = Console.ReadLine();
            int num;
            bool valid = int.TryParse(input, out num);
            while (!valid)
            {
                Console.WriteLine($"Erro: {input} não é um numero valido. Por favor coloque uma das opções disponiveis.");
                Menu();
                input = Console.ReadLine();
                valid = int.TryParse(input, out num);
            }
            while (num != 5)
            {
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Lista de Tarefas");
                        Console.WriteLine("=============");
                        string done = "n";
                        while (done == "n")
                        {

                            {
                                for (int i = 0; i < taskList.Count; i++)
                                {
                                    Console.WriteLine($"Tarefa {i + 1}: ");
                                    Console.WriteLine("~~~~~~~~~~");
                                    Console.WriteLine($"Nome da Tarefa: {taskList[i].taskname}");
                                    Console.WriteLine($"Descrição da tarefa: {taskList[i].description}");
                                    Console.WriteLine($"Tempo Limite da tarefa: {taskList[i].duedate}");
                                    Console.WriteLine($"Tarefa completada? {taskList[i].completed}");


                                }
                               

                            }
                            Console.WriteLine("\nVoltar para o Menu Principal? (s/n)");
                            done = Console.ReadLine();
                            BackToMain(done);
                        }
                        Menu();
                        input = Console.ReadLine();
                        valid = int.TryParse(input, out num);

                        break;
                    case 2: 
                        Console.WriteLine("Adicione novas tarefas: ");
                        Console.WriteLine("===================");
                        string cont = "S";
                        while (cont.ToUpper() == "S")
                        {
                            Console.WriteLine("Escreva o nome da tarefa: ");
                            string task = Console.ReadLine();
                            Console.WriteLine("Escreva a descrição da tarefa: ");
                            string description = Console.ReadLine();
                            Console.WriteLine("Coloque a data limite da tarefa: ");
                            string dateInput = Console.ReadLine();
                            DateTime duedate;
                            bool validDate = DateTime.TryParse(dateInput, out duedate);
                            while (!validDate)
                            {
                                ErrorMessage();
                                Console.WriteLine("Coloque a data limite da tarefa: ");
                                dateInput = Console.ReadLine();
                                validDate = DateTime.TryParse(dateInput, out duedate);

                            }
                            taskList.Add(new Task(task, description, duedate)); 
                            Console.WriteLine("Tarefa adicionada como sucesso! Adicionar outra?? (s/n)");
                            cont = Console.ReadLine();
                            BackToMain(cont);
                        }
                        Menu();
                        input = Console.ReadLine();
                        valid = int.TryParse(input, out num);

                        break;
                    case 3:
                        Console.WriteLine("Deletar Tarefa da Lista: ");
                        Console.WriteLine("======================");
                        string another = "s";
                        while (another.ToLower() == "s")
                        {
                            Console.WriteLine($"Entre o numero da tarefa que você quer deletar: 1-{taskList.Count}");
                            string item = Console.ReadLine();
                            int delNum;
                            bool validNum = int.TryParse(item, out delNum);
                            while (!validNum || delNum > taskList.Count || delNum < 0) 
                            {
                                ErrorMessage();
                                Console.WriteLine($"Entre o numero da tarefa que você quer deletar: 1-{taskList.Count}");
                                item = Console.ReadLine();
                                validNum = int.TryParse(item, out delNum);
                            }

                            taskList.RemoveAt(delNum - 1);

                            Console.WriteLine("Item deletado com sucesso! Deseja deletar outro? (s/n)");
                            another = Console.ReadLine();
                            BackToMain(another);
                        }
                        Menu();
                        input = Console.ReadLine();
                        valid = int.TryParse(input, out num);
                        break;
                    case 4:
                        Console.WriteLine("Marcação de Tarefa: ");
                        Console.WriteLine("====================");
                        string again = "s";
                        while (again.ToLower() == "s")
                        {
                            Console.WriteLine($"Entre o numero da tarefa que você quer completar: 1-{taskList.Count}");
                            string item = Console.ReadLine();
                            int completedNum;
                            bool validCom = int.TryParse(item, out completedNum);
                            while (!validCom || completedNum > taskList.Count || completedNum < 0) 
                            {
                                ErrorMessage();
                                Console.WriteLine($"Entre o numero da tarefa que você quer completar: 1-{taskList.Count}");
                                item = Console.ReadLine();
                                validCom = int.TryParse(item, out completedNum);
                            }

                            taskList[completedNum - 1].completed = true;

                            Console.WriteLine("Tarefa selecionada completada! Selecionar outra? (s/n)");
                            again = Console.ReadLine();
                            BackToMain(again);
                        }
                        Menu();
                        input = Console.ReadLine();
                        valid = int.TryParse(input, out num);
                        break;
                    default:
                        ErrorMessage();
                        Menu();
                        input = Console.ReadLine();
                        valid = int.TryParse(input, out num);
                        break;
                }

            }
            
            Console.WriteLine("Aperte qualquer botão para sair...");
            Console.ReadKey();

        }
        static void Menu()
        {
            Console.WriteLine("Criador de Tarefas");
            Console.WriteLine("=============");
            Console.WriteLine("1 - Listar Tarefas");
            Console.WriteLine("2 - Adicionar Tarefas");
            Console.WriteLine("3 - Deletar Tarefas");
            Console.WriteLine("4 - Marcar tarefa como concluida");
            Console.WriteLine("5 - Fechar o Progama");

        }

        static void BackToMain(string input)
        {
            while (input.ToLower() != "s" && input.ToLower() != "n")
            {
                Console.WriteLine("Erro: Isso não é uma opção por favor escolha entre s ou n");
                Console.WriteLine("Add another item? (s/n)");
                input = Console.ReadLine();
            }
        }

        static void ErrorMessage()
        {
            Console.WriteLine("Erro:Você colocou uma informação incorreta.Por favor tente de novo.");

        }
    } 
   }
