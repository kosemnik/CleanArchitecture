using System;
using System.Collections.Generic;
using System.Text;

namespace OilPastelChoise
{
    class ConsoleUI
    {
        private OilPastelCollection oilPastels;

        public ConsoleUI()
        {
            oilPastels = new OilPastelCollection();
        }

        public void StartUI()
        {
            PrintMenu();
            while (true)
            {
                var answer = Console.ReadLine();
                int parseAnswer;
                if (int.TryParse(answer, out parseAnswer) && parseAnswer == 1)
                    ReadAll();
                else if (int.TryParse(answer, out parseAnswer) && parseAnswer == 2)
                    FindOilPastel();
                else if (int.TryParse(answer, out parseAnswer) && parseAnswer == 3)
                    AddOilPastel();
                else if (int.TryParse(answer, out parseAnswer) && parseAnswer == 4)
                    UpdateOilPastel();
                else if (int.TryParse(answer, out parseAnswer) && parseAnswer == 5)
                    DeleteOilPastel();
                else
                    Console.WriteLine("Выберите пункт 1 - 5");
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("1 - показать список пастели;");
            Console.WriteLine("2 - подобрать пастель по критериям;");
            Console.WriteLine("3 - добавить новую пастель;");
            Console.WriteLine("4 - редактировать позицию;");
            Console.WriteLine("5 - удалить позицию из списка");
            Console.WriteLine();
        }

        private void ReadAll()
        {
            if (oilPastels.ReadAll().Count == 0)
                Console.WriteLine("Результатов нет");
            else
                foreach (var item in oilPastels.ReadAll())
                    PrintItem(item);
            PrintMenu();
        }

        private void PrintItem(OilPastel item)
        {
            Console.WriteLine("Id - " + item.Id);
            Console.WriteLine("Бренд - " + item.Brand);
            Console.WriteLine("Название - " + item.Name);
            Console.WriteLine("Уровень пользователя - " + item.UserLevel);
            Console.WriteLine("Количество цветов - " + item.ColorNumber);
            Console.WriteLine("Страна производства - " + item.OriginCountry);
            Console.WriteLine("Цена - " + item.Price + "\n");
        }

        private void FindOilPastel()
        {
            var answer = GetAnswer("Выберите критерий, по которому бует происходить поиск.\n" +
                "1. Бренд;\n" +
                "2. Уровень пользователя;\n" +
                "3. Количество цветов;\n" +
                "4. Цена");
            int procedureNumber;
            while (!int.TryParse(answer, out procedureNumber) || 
                int.TryParse(answer, out procedureNumber) && (procedureNumber < 1 || procedureNumber > 4))
                Console.WriteLine("Введите верное целочисленное значение");

            var result = new List<OilPastel>();
            if (procedureNumber == 1)
                result = FindForBrand();
            else if (procedureNumber == 2)
                result = FindFofUserLevel();
            else if (procedureNumber == 3)
                result = FindForColorNumber();
            else
                result = FindForPrice();

            if (result.Count == 0)
                Console.WriteLine("Результатов нет");
            else
                foreach (var item in result)
                    PrintItem(item);

            PrintMenu();
        }
        private List<OilPastel> FindForBrand()
        {
            return oilPastels.FindForBrand(GetAnswer("Бренд: "));
        }

        private List<OilPastel> FindFofUserLevel()
        {
            return oilPastels.FindFofUserLevel(GetAnswer("Уровень пользователя: "));
        }

        private List<OilPastel> FindForColorNumber()
        {
            int colorNumber;
            while (!int.TryParse(GetAnswer("Количество цветов: "), out colorNumber))
                Console.WriteLine("Введите целочисленное значение");
            return oilPastels.FindForColorNumber(colorNumber);
        }

        private List<OilPastel> FindForPrice()
        {
            int minPrice;
            while (!int.TryParse(GetAnswer("Минимальная цена: "), out minPrice))
                Console.WriteLine("Введите целочисленное значение");
            int maxPrice;
            while (!int.TryParse(GetAnswer("Максимальная цена: "), out maxPrice))
                Console.WriteLine("Введите целочисленное значение");
            return oilPastels.FindForPrice(minPrice, maxPrice);
        }

        private void AddOilPastel()
        {
            oilPastels.AddPastel(GetNewItem());
            Console.WriteLine("Данные успешно добавлены\n");
            PrintMenu();
        }
        
        private OilPastel GetNewItem()
        {
            var brand = GetAnswer("Бренд: ");
            var name = GetAnswer("Название: ");
            var userLevel = GetAnswer("Уровень пользователя: ");
            int colorNumber;
            while (!int.TryParse(GetAnswer("Количество цветов: "), out colorNumber))
                Console.WriteLine("Введите целочисленное значение");
            var originCountry = GetAnswer("Страна производства: ");
            int price;
            while (!int.TryParse(GetAnswer("Цена: "), out price))
                Console.WriteLine("Введите целочисленное значение");

            var newItem = new OilPastel()
            {
                Brand = brand,
                Name = name,
                UserLevel = userLevel,
                ColorNumber = colorNumber,
                OriginCountry = originCountry,
                Price = price
            };

            return newItem;
        }

        private void UpdateOilPastel()
        {
            var id = GetAnswer("Введите Id пастели для редактирования:");
            while (!int.TryParse(id, out _) || int.TryParse(id, out int intId) && (intId < 0 || intId > oilPastels.ReadAll().Count))
            {
                Console.WriteLine("Введите верное значение Id");
                id = Console.ReadLine();
            }

            oilPastels.UpdateOilPastel(int.Parse(id), GetNewItem());

            Console.WriteLine("Данные успешно изменены\n");
            PrintMenu();
        }

        private void DeleteOilPastel()
        {
            var id = GetAnswer("Введите Id пастели для удаления:");
            while (!int.TryParse(id, out _)
                || int.TryParse(id, out int intId) && (intId < 0 || intId > oilPastels.ReadAll().Count))
            {
                Console.WriteLine("Введите верное значение Id");
                id = Console.ReadLine();
            }

            oilPastels.DeleteOilPastel(int.Parse(id));
            Console.WriteLine("Данные успешно удалены\n");
            PrintMenu();
        }

        private string GetAnswer(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}
