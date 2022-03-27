using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCurs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticlePage : ContentPage
    {
        public ArticlePage(string title)
        {
            InitializeComponent();
            GetHowToProperlyPlan(title);
        }

        public void GetHowToProperlyPlan(string titel)
        {
            TitleText.Text = titel;
            ContentLabel.Text = "Most of us understand the value of planning and preparation. A sports match without a game plan means fumbling on the field. A big event without all the details in place leads to chaos.\n\n" +
                "Despite this knowledge, we often fail to prioritize planning where it matters most: our daily lives.Getting started in the morning without a clear plan sets us up to fail.\n\n" +
                "We set goals on the order of seasons and years, but it’s what we do each day — the habits we adopt, the tasks we complete, and the things we prioritize — that compound over time into success or failure. A few aimless days each month can help us reset and find balance.But when our days without intention exceed our days with purpose, we end up missing our goals and wondering where all the time went.\n\n" +
                "The best defense against hectic yet unproductive days is a good offense in the form of a daily planning ritual.This article will walk you through how to plan your days for calmer, more focused productivity that brings you closer to your goals.While planning your day should only take 10 - 15 minutes, the underlying strategies to meaningfully craft a day with intention are worth exploring in full.\n\n" +
                "Make regular planning a habit\n\n" +
                "James Clear, the best - selling author of Atomic Habits, thinks motivation is overrated: “Stop waiting for motivation or inspiration to strike you and set a schedule for your habits”. Motivation flows from action, not the other way around.\n\n" +
                "That’s why having a daily planning ritual is so important. Some mornings we feel motivated to seize the day and create a to -do list that reflects our big ambitions.But those days are the exception. We need to get things done even when we wake up tired and disengaged, wanting to return to bed or longing for Friday at 5 PM.Those are the days it’s most important to approach the day with a plan.\n\n" +
                "Start by setting an alarm for your daily planning session at the same time every day — either during a work shutdown ritual or first thing in the morning.To make building the habit easier, bundle your new daily planning session with an existing habit like drinking your morning coffee or listening to music.\n\n";
        }
    }
}