using AdvanceTaskMarsPart1.AssertHelpers;
using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Pages.Components.ProfileOverview;
using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Steps
{
    public class SearchSkillSteps : BaseSetUp
    {
        SearchSkillComponent searchSkillComponent;

        public SearchSkillSteps()
        {
            searchSkillComponent = new SearchSkillComponent();
        }

        public void searchSkillCategory()
        {
            List<SearchSkillData> searchSkillDataList = JsonReader.LoadData<SearchSkillData> (@"searchSkillData.json");
            foreach (var searchSkillData in searchSkillDataList)
            {
                searchSkillComponent.clickSearchButton(searchSkillData);
                searchSkillComponent.SearchSkillCategory();
                searchSkillComponent.SearchSkillSubcategory();
                List<IWebElement> skillList = searchSkillComponent.getSkillList();
                // Check if the skillList contains elements
                if (skillList.Count > 0)
                {
                    // If the skillList is not empty, each skill is displayed
                    foreach (var skill in skillList)
                    {
                        SearchSkillAssertHelper.assertSkillListNotEmpty(skill.Displayed);
                    }
                }
                else
                {
                    //If the skillList is empty, print a message SkillList is empty
                    SearchSkillAssertHelper.assertSkillListEmpty(skillList);
                    string Message = searchSkillComponent.getMessage();
                    Console.WriteLine(Message);
                }
            }
        }

        public void searchSkillFilters()
        {
            List<SearchSkillData> searchSkillDataList = JsonReader.LoadData<SearchSkillData>(@"searchSkillData.json");
            foreach (var searchSkillData in searchSkillDataList)
            {
                searchSkillComponent.clickSearchButton(searchSkillData);
                searchSkillComponent.SearchSkillFilters();
                List<IWebElement> skillList = searchSkillComponent.getSkillList();
                // Check if the skillList contains elements
                if (skillList.Count > 0)
                {
                    // If the skillList is not empty, each skill is displayed
                    foreach (var skill in skillList)
                    {
                        SearchSkillAssertHelper.assertSkillListNotEmpty(skill.Displayed);
                    }
                }
                else
                {
                    //If the skillList is empty, print a message SkillList is empty
                    SearchSkillAssertHelper.assertSkillListEmpty(skillList);
                    string Message = searchSkillComponent.getMessage();
                    Console.WriteLine(Message);
                }
            }
        }
    }
}
