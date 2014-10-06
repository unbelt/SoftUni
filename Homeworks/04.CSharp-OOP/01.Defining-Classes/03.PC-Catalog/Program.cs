using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        Component boxPC = new Component(name: "Кутия Shenha V6", price: 55.20m, details: "Размер: 475 x 185 x 465 cm");
        Component motherboard = new Component(name: "Дънна платка ASROCK FM2A88X Extreme6+", price: 188.40m);
        Component hdd = new Component(name: "Диск SEAGATE 2T, ES.3, SATA III", price: 330m, details: "Капацитет: 2 TB");
        Component procesor = new Component(name: "Процесор Intel Core I3-4340", price: 316.80m);
        Component graficsCard = new Component(name: "Видео карта PALIT GeForce GT 610", price: 80.40m, details: "Видео памет размер: 1 GB");
        Component ram = new Component(name: "Памет ADATA 2X4GB", price: 171.60m, details: "Описание: 2X4G DDR3");

        Component discSSD = new Component(name: "Диск A-DATA 128GB SSD", price: 127.20m, details: "Описание: Multi-Level Cell (MLC) NAND Flash Memory, 2.5 inch");
        Component blower = new Component(name: "Вентилатор COOLERMASTER Blade Master 80", price: 16.80m);
        Component power = new Component(name: "PSU FD 750W INTEGRA BLACK", price: 157.20m, details: "Описание: Multi-Level Cell (MLC) NAND Flash Memory, 2.5 inch");

        Computer computer1 = new Computer(
            name: "Frankenstein",
            boxPC: boxPC,
            motherboard: motherboard,
            hdd: hdd,
            procesor: procesor,
            graficsCard: graficsCard,
            ram: ram
        );

        Computer computer2 = new Computer("The Мachine", boxPC, motherboard, hdd, procesor, graficsCard, ram, discSSD, blower, power);

        Computer computer3 = new Computer("SbirotakModel", boxPC, motherboard, hdd, procesor, graficsCard, ram, discSSD);

        List<Computer> computers = new List<Computer>() { computer2, computer1, computer3, computer1 };


        computers = computers.OrderBy(computer => computer.Price).ToList();

        foreach (var computer in computers)
        {
            computer.writeToConsole();
            Console.WriteLine();
        }

    }
}
