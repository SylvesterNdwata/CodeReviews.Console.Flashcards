using silvermax.FlashCards.Controllers;
using Spectre.Console;
using static silvermax.FlashCards.Enums;

namespace silvermax.FlashCards;

internal class UserInterface
{
    public void Start()
    {
        DatabaseController controller = new();
        FlashCardController flashCardController = new();
        StacksController stacksController = new();

        controller.InitTables();

        bool openApp = true;
        while (openApp)
        {
            Console.Clear();
            var choice = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOptions>()
            .Title("Welcome to the Flash card app.")
            .UseConverter(e => Enums.ToDisplayName(e))
            .AddChoices(Enum.GetValues<MenuOptions>()));

            switch (choice)
            {
                case MenuOptions.ManageFlashcards:
                    flashCardController.Start();
                    break;

                case MenuOptions.ManageStacks:
                    stacksController.GetAllStacks();
                    stacksController.Start();
                    break;

                case MenuOptions.exit:
                    openApp = false;
                    break;
            }
        }
        
    }
}
