namespace lab2 {
    internal class Program {
        static void Main() {
            var queries = new Queries();
            queries.SelectOneRelation();
            queries.SelectOneRelationWithFilter("путешествий");
            queries.SelectManyRelationWithAgregation();
            queries.SelectOneToManyRelationWithJoin();
            queries.SelectOneToManyRelationWithJoinAndFilter(90, "Штатный работник");

            var newInsuranceType = new InsuranceType() {
                Name = "Страхование грузоперевозок",
                Description = "оформляется в случае регулярных перевозок по согласованным маршрутам или при перевозках однородных грузов."
            };
            //queries.InsertOneRelation(newInsuranceType);

            var newInsuranceAgent = new InsuranceAgent() {
                Name = "Иван",
                MiddleName = "Иванов",
                Surname = "Иванов",
                Salary = 20,
                TransactionPercent = 0.1,
                AgentType = 1,
                Contract = 1
            };
            //queries.InsertManyRelation(newInsuranceAgent);

            //queries.DeleteOneRelation(newInsuranceType);

            //queries.DeleteManyRelation(newInsuranceAgent);

            queries.UpdateWithCondition(10, -0.1);
        }
    }
}