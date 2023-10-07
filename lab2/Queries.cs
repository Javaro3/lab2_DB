using Microsoft.Identity.Client;

namespace lab2 {
    public class Queries {
        public void SelectOneRelation() {
            Console.WriteLine("1. Выборка данных из таблицы на стороне отношения 'один'");
            Console.WriteLine("Контракты страховых агентов");
            Console.WriteLine(new string('-', 50));
            using (var context = new InsuranceCompanyContext()) {
                var contracts = context.Contracts;
                foreach (var contract in contracts) {
                    Console.WriteLine($"{contract.Id} | {contract.Responsibilities} | {contract.StartDeadline}-{contract.EndDeadline}");
                }
            }
            Console.WriteLine("\n\n");
        }

        public void SelectOneRelationWithFilter(string filter) {
            Console.WriteLine("2. Выборка данных из таблицы на стороне отношения 'один' с фильтрацией данных");
            Console.WriteLine($"Страховые случаи которые в названии содержат '{filter}'");
            Console.WriteLine(new string('-', 50));
            using (var context = new InsuranceCompanyContext()) {
                var insuranceTypes = context.InsuranceTypes.Where(e => e.Name.Contains(filter));
                foreach (var insuranceType in insuranceTypes) {
                    Console.WriteLine($"{insuranceType.Id} | {insuranceType.Name} | {insuranceType.Description}");
                }
            }
            Console.WriteLine("\n\n");
        }

        public void SelectManyRelationWithAgregation() {
            Console.WriteLine("3. Выборка данных из таблицы на стороне отношения 'многие' с агрегацией данных");
            Console.WriteLine($"Средняя зарплата страховых агентов");
            Console.WriteLine(new string('-', 50));
            using (var context = new InsuranceCompanyContext()) {
                var insuranceAgentsAvgSalary = context.InsuranceAgents.Average(e => e.Salary);
                Console.WriteLine(insuranceAgentsAvgSalary);
            }
            Console.WriteLine("\n\n");
        }

        public void SelectOneToManyRelationWithJoin() {
            Console.WriteLine("4. Выборка данных из таблиц на стороне отношения 'один-многие' с join");
            Console.WriteLine($"Страховой агент (ФИО - тип дожности)");
            Console.WriteLine(new string('-', 50));
            using (var context = new InsuranceCompanyContext()) {
                var result = from insuranceAgents in context.InsuranceAgents
                             join agentType in context.AgentTypes
                             on insuranceAgents.AgentType equals agentType.Id
                             select new {
                                 insuranceAgents.Name,
                                 insuranceAgents.Surname,
                                 insuranceAgents.MiddleName,
                                 agentType.Type
                             };

                foreach (var insuranceAgent in result) {
                    Console.WriteLine($"{insuranceAgent.Name} {insuranceAgent.Surname} {insuranceAgent.MiddleName} | {insuranceAgent.Type}");
                }
            }
            Console.WriteLine("\n\n");
        }

        public void SelectOneToManyRelationWithJoinAndFilter(decimal salary, string agentType) {
            Console.WriteLine("5. Выборка данных из таблиц на стороне отношения 'один-многие' с фильтрацией данных по определенному условию");
            Console.WriteLine($"Страховой агент с зарплатой больше {salary} и типом работника - {agentType}");
            Console.WriteLine(new string('-', 50));
            using (var context = new InsuranceCompanyContext()) {
                var result = from insuranceAgents in context.InsuranceAgents
                             join agentT in context.AgentTypes
                             on insuranceAgents.AgentType equals agentT.Id
                             where insuranceAgents.Salary > salary && agentT.Type == agentType
                             select new {
                                 insuranceAgents.Name,
                                 insuranceAgents.Surname,
                                 insuranceAgents.MiddleName,
                                 insuranceAgents.Salary,
                                 agentT.Type
                             };

                foreach (var insuranceAgent in result) {
                    Console.WriteLine($"{insuranceAgent.Name} {insuranceAgent.Surname} {insuranceAgent.MiddleName} | {insuranceAgent.Salary} | {insuranceAgent.Type}");
                }
            }
            Console.WriteLine("\n\n");
        }

        public void InsertOneRelation(InsuranceType insuranceType) {
            Console.WriteLine("6. Вставку данных в таблицу, стоящей на стороне отношения 'Один'");
            Console.WriteLine($"Вставка в таблицу вид страхования:\n\tНазвание - {insuranceType.Name}\n\tОписание - {insuranceType.Description}");
            using (var context = new InsuranceCompanyContext()) {
                context.InsuranceTypes.Add(insuranceType);
                context.SaveChanges();
                Console.WriteLine("ДАННЫЕ УСПЕШНО СОХРАНЕНЫ!!!");
            }
            Console.WriteLine("\n\n");
        }

        public void InsertManyRelation(InsuranceAgent insuranceAgent) {
            Console.WriteLine("7. Вставку данных в таблицу, стоящей на стороне отношения 'Многие'");
            using (var context = new InsuranceCompanyContext()) {
                var agentType = context.AgentTypes.FirstOrDefault(e => e.Id == insuranceAgent.AgentType);
                var contract = context.Contracts.FirstOrDefault(e => e.Id == insuranceAgent.Contract);
                insuranceAgent.AgentTypeNavigation = agentType;
                insuranceAgent.ContractNavigation = contract;
                
                Console.WriteLine($"Вставка в таблицу страховой агент:" +
                $"\n\tФИО - {insuranceAgent.Surname} {insuranceAgent.Name} {insuranceAgent.MiddleName}" +
                $"\n\tТип страхового агента - {agentType.Type}" +
                $"\n\tЗарплата - {insuranceAgent.Salary}" +
                $"\n\tПроцент от сделки - {insuranceAgent.TransactionPercent}" +
                $"\n\tКонтракт:" +
                $"\n\t\tОбязанности - {contract.Responsibilities}" +
                $"\n\t\tДата начала работы - {contract.StartDeadline.ToShortDateString()}" +
                $"\n\t\tДата конца работы - {contract.EndDeadline.ToShortDateString()}");
                
                context.InsuranceAgents.Add(insuranceAgent);
                context.SaveChanges();
                Console.WriteLine("ДАННЫЕ УСПЕШНО СОХРАНЕНЫ!!!");
            }
            Console.WriteLine("\n\n");
        }

        public void DeleteOneRelation(InsuranceType insuranceType) {
            Console.WriteLine("8. Удаление данных из таблицы, стоящей на стороне отношения 'Один'");
            using (var context = new InsuranceCompanyContext()) {
                
                Console.WriteLine($"Удаление из таблицы вид стразования:" +
                $"\n\tНазвание - {insuranceType.Name}" +
                $"\n\tОписание - {insuranceType.Description}");
                
                var removeInsuraceType = context.InsuranceTypes.FirstOrDefault(e => e.Name.Contains(insuranceType.Name));
                context.InsuranceTypes.Remove(removeInsuraceType);
                context.SaveChanges();
                Console.WriteLine("ДАННЫЕ УСПЕШНО УДАЛЕНЫ!!!");
            }
            Console.WriteLine("\n\n");
        }

        public void DeleteManyRelation(InsuranceAgent insuranceAgent) {
            Console.WriteLine("9. Удаление данных из таблицы, стоящей на стороне отношения 'Многие'");
            using (var context = new InsuranceCompanyContext()) {
                var agentType = context.AgentTypes.FirstOrDefault(e => e.Id == insuranceAgent.AgentType);
                var contract = context.Contracts.FirstOrDefault(e => e.Id == insuranceAgent.Contract);
                insuranceAgent.AgentTypeNavigation = agentType;
                insuranceAgent.ContractNavigation = contract;

                Console.WriteLine($"Вставка в таблицу страховой агент:" +
                $"\n\tФИО - {insuranceAgent.Surname} {insuranceAgent.Name} {insuranceAgent.MiddleName}" +
                $"\n\tТип страхового агента - {agentType.Type}" +
                $"\n\tЗарплата - {insuranceAgent.Salary}" +
                $"\n\tПроцент от сделки - {insuranceAgent.TransactionPercent}" +
                $"\n\tКонтракт:" +
                $"\n\t\tОбязанности - {contract.Responsibilities}" +
                $"\n\t\tДата начала работы - {contract.StartDeadline.ToShortDateString()}" +
                $"\n\t\tДата конца работы - {contract.EndDeadline.ToShortDateString()}");

                var removeInsuraceAgent = context.InsuranceAgents.FirstOrDefault(e => 
                    e.Name.Contains(insuranceAgent.Name) &&
                    e.Surname.Contains(insuranceAgent.Surname) &&
                    e.MiddleName.Contains(insuranceAgent.MiddleName));
                
                context.InsuranceAgents.Remove(removeInsuraceAgent);
                context.SaveChanges();
                Console.WriteLine("ДАННЫЕ УСПЕШНО УДАЛЕНЫ!!!");
            }
            Console.WriteLine("\n\n");
        }

        public void UpdateWithCondition(decimal salary, double transactionPercentPlus) {
            Console.WriteLine("10. Обновления данных в таблице");
            Console.WriteLine($"Увеличение процента от сделки стразовых агентов на {transactionPercentPlus} у кого зарплата меньше {salary}");
            using (var context = new InsuranceCompanyContext()) {

                var insuranceAgents = context.InsuranceAgents.Where(e => e.Salary < salary);

                foreach (var agent in insuranceAgents) {
                    agent.TransactionPercent += transactionPercentPlus + agent.TransactionPercent >= 1 ? 1 : transactionPercentPlus;
                }

                context.SaveChanges();
                Console.WriteLine("ДАННЫЕ УСПЕШНО ОБНОВЛЕНЫ!!!");
            }
            Console.WriteLine("\n\n");
        }
    }
}
