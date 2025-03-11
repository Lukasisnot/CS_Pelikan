using simpleDuolingo.Views;
namespace simpleDuolingo;

public partial class BaseForm : Form
{
    private Navigation navigationView;
    private Users _usersView;
    
    public DBDriver _dbDriver;

    private UserControl _currentView;
    
    public enum ViewType
    {
        Navigation,
        User
    }

    public BaseForm ()
    {
        InitializeComponent();
        _dbDriver = new DBDriver();
        navigationView = new Navigation(this, _dbDriver);
        _usersView = new Users(this, _dbDriver);
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
            ViewType.Navigation => navigationView,
            ViewType.User => _usersView,
        };
        RenderCurrentView();
    }
}