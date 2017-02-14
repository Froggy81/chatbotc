using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
public class BasicLuisDialog : LuisDialog<object>
{
    public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(Utils.GetAppSetting("LuisAppId"), Utils.GetAppSetting("LuisAPIKey"))))
    {
    }

    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the none intent. You said: {result.Query}"); //
        context.Wait(MessageReceived);
    }

    // Go to https://luis.ai and create a new intent, then train/publish your luis app.
    // Finally replace "MyIntent" with the name of your newly created intent in the following handler
    [LuisIntent("MyIntent")]
    public async Task MyIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the MyIntent intent. You said: {result.Query}"); //
        context.Wait(MessageReceived);
    }

    [LuisIntent("tickets")]
    public async Task TicketIntent(IDialogContext context, LuisResult result)
    {
        var recommendation = result.Entities.FirstOrDefault();
        //getTickets(recommendation);
       
        await context.PostAsync($"You have asked about tickets with your query: {result.Query}"); //
        await context.PostAsync($"You sent me these entities: " + recommendation.entity);
        
        context.Wait(MessageReceived);
    }

    [LuisIntent("Welcome")]
    public async Task WelcomeIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You say hello I say hello {result.Query}"); //
        context.Wait(MessageReceived);
    }

    [LuisIntent("footballclub")]
    public async Task FootballClubIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"What would you like to know about the Port Adelaide Football club?"); //
        context.Wait(MessageReceived);
    }    
}