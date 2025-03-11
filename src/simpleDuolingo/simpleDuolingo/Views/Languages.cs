using simpleDuolingo.Entities;

namespace simpleDuolingo.Views;

public partial class Languages : UserControl
{
    private readonly BaseForm _parentForm;
    private readonly LanguageRepository _languageRepository;

    public Languages(BaseForm parentForm, DBDriver dbDriver)
    {
        _parentForm = parentForm;
        _languageRepository = new LanguageRepository(dbDriver);
        InitializeComponent();
        LoadLangs();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        _parentForm.SelectView(BaseForm.ViewType.Navigation);
    }
    
    private void PopulateListView(List<Language> languages)
    {
        listView2.Items.Clear();
        foreach (var language in languages)
        {
            ListViewItem item = new ListViewItem();
            item.Text = language.Id.ToString();
            item.SubItems.Add(language.Name);
            item.SubItems.Add(language.CreatedAt.ToString());
            item.SubItems.Add(language.ModifiedAt.ToString());
            listView2.Items.Add(item);
        }
    }
    
    private void LoadLangs()
    {
        List<Language> languages = _languageRepository.GetLang();
        if (_languageRepository.ThrownException is not null)
        {
            textBox3.Text = _languageRepository.ThrownException.Message;
            _languageRepository.ThrownException = null;
            // _userRepository = null;
        }
        else
        {
            PopulateListView(languages);
        }
    }

    private void button4_Click(object sender, EventArgs e)
    {
        LoadLangs();
        textBox3.Text = "";
    }

    private void button2_Click(object sender, EventArgs e)
    {
        InsertLang();
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            InsertLang();
        }
    }

    private void InsertLang()
    {
        if (textBox1.Text == "") return;
        
        _languageRepository.InsertLang(textBox1.Text);
        LoadLangs();
        textBox1.Text = "";
    }
    
    private void DeleteLangWithId()
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
        _languageRepository.DeteteLangWithId(id);
        if (_languageRepository?.ThrownException is not null)
        {
            textBox3.Text = _languageRepository.ThrownException.Message;
            _languageRepository.ThrownException = null;
            return;
        }
        LoadLangs();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        DeleteLangWithId(); 
    }

    private void textBox2_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            DeleteLangWithId();
        }
    }
}