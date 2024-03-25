using AdvanceTaskMarsPart1.Data;
using AdvanceTaskMarsPart1.Pages.Components.SignIn;
using AdvanceTaskMarsPart1.Utilities;

namespace AdvanceTaskMarsPart1.Steps
{
    public class LoginSteps
    {
        SignInComponent signInComponent;
        LoginComponent loginComponent;

        public LoginSteps()
        {
            signInComponent = new SignInComponent();
            loginComponent = new LoginComponent();
        }

        public void doLogin()
        {
            List<UserInformation> userInformatioList = JsonReader.LoadData<UserInformation>(@"UserInformation.json");
            foreach (var userInformation in userInformatioList)
            {
                signInComponent.clickSignInButton();
                loginComponent.LoginActions(userInformation);
            }
        }
    }
}
