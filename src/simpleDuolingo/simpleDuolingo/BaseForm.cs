using simpleDuolingo.Views;
namespace simpleDuolingo;

public partial class BaseForm : Form
{
    private Navigation _navigationView;
    private Users _usersView;
    private Languages _languagesView;
    
    public DBDriver _dbDriver;

    private UserControl _currentView;
    
    public enum ViewType
    {
        Navigation,
        User,
        Language
    }

    public BaseForm ()
    {
        InitializeComponent();
        _dbDriver = new DBDriver();
        _navigationView = new Navigation(this, _dbDriver);
        _usersView = new Users(this, _dbDriver);
        _languagesView = new Languages(this, _dbDriver);
        SelectView(ViewType.Navigation);
    }

    public void RenderCurrentView()
    {
        this.Controls.Clear();
        this.Controls.Add(_currentView);
    }

    public void SelectView(ViewType viewType)
    {
        _currentView = viewType switch
        {
            ViewType.Navigation => _navigationView,
            ViewType.User => _usersView,
            ViewType.Language => _languagesView,
        };
        RenderCurrentView();
    }
}