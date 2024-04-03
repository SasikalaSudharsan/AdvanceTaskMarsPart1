using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Utilities;
using OpenQA.Selenium;

namespace AdvanceTaskMarsPart1.Pages.Components.ProfileOverview
{
    public class ProfileSkillOverviewComponent : BaseSetUp
    {
        private IWebElement AddNewButton;
        private IWebElement UpdateButton;
        private IWebElement DeleteButton;

        public void renderAddButton()
        {
            try
            {
                AddNewButton = driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//th[@class='right aligned']//div"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderUpdateButton(string existingSkill, string existingSkillLevel)
        {
            try
            {
                UpdateButton = driver.FindElement(By.XPath($"//div[@data-tab='second']//tr[td[1]='{existingSkill}' and td[2]='{existingSkillLevel}']//td[last()]/span[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderDeleteButton(string skill, string skillLevel)
        {
            try
            {
                DeleteButton = driver.FindElement(By.XPath($"//div[@data-tab='second']//tr[td[1]='{skill}' and td[2]='{skillLevel}']//td[last()]/span[2]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickAddSkillButton()
        {
            renderAddButton();
            AddNewButton.Click();
        }

        public void clickUpdateSkillButton(SkillData existingSkillData)
        {
            string existingSkill = existingSkillData.Skill;
            string existingSkillLevel = existingSkillData.SkillLevel;
            Thread.Sleep(4000);
            renderUpdateButton(existingSkill, existingSkillLevel);
            UpdateButton.Click();
        }

        public void clickDeleteSkillButton(SkillData skillData)
        {
            string skill = skillData.Skill;
            string skillLevel = skillData.SkillLevel;
            Thread.Sleep(4000);
            renderDeleteButton(skill, skillLevel);
            DeleteButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
        }
    }
}
