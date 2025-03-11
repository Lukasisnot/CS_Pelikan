using simpleDuolingo.Entities;

namespace simpleDuolingo.Views;

public partial class Users : UserControl
{
    private readonly BaseForm _parentForm;
    private readonly UserRepository _userRepository;

    public Users(BaseForm parentForm, DBDriver dbDriver)
    {
        _parentForm = parentForm;
        _userRepository = new UserRepository(dbDriver);
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        _parentForm.SelectView(BaseForm.ViewType.Navigation);
    }
    
    private void PopulateListView(List<User> users)
    {
        listView2.Items.Clear();
        foreach (var user in users)
        {
            ListViewItem item = new ListViewItem();
            item.Text = user.Id.ToString();
            item.SubItems.Add(user.Username);
            item.SubItems.Add(user.CreatedAt.ToString());
            item.SubItems.Add(user.ModifiedAt.ToString());
            listView2.Items.Add(item);
        }
    }
    
    private void LoadUsers()
    {
        List<User> users = _userRepository.GetUsers();
        if (_userRepository.ThrownException is not null)
        {
            textBox3.Text = _userRepository.ThrownException.Message;
            _userRepository.ThrownException = null;
            // _userRepository = null;
        }
        else
        {
            PopulateListView(users);
        }
    }

    private void button4_Click(object sender, EventArgs e)
    {
        LoadUsers();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        InsertUser();
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        InsertUser();
    }

    private void InsertUser()
    {
        if (textBox1.Text == "") return;
        
        _userRepository.InsertUser(textBox1.Text);
        LoadUsers();
        textBox1.Text = "";
    }
    
    private void DeleteUserWithId()
    {
        if (textBox2.Text == "") return;
        
        string stringId = textBox2.Text;
        textBox2.Text = "";
        textBox3.Text = "";
        int id;
        
        if (int.TryParse(stringId, out id) is false)
        {
            textBox3.Text = "Please enter a valid ID";
            return;
        }
        _userRepository.DeteteUserWithId(id);
        if (_userRepository?.ThrownException is not null)
        {
            textBox3.Text = _userRepository.ThrownException.Message;
            _userRepository.ThrownException = null;
            return;
        }
        LoadUsers();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        DeleteUserWithId();        
    }
}