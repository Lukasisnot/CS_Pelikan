namespace simpleDuolingo.Views;

public partial class Navigation : UserControl
{
    private readonly BaseForm _parentForm;
    private readonly DBDriver _dbDriver;

    public Navigation(BaseForm parentForm, DBDriver dbDriver)
    {
        _parentForm = parentForm;
        _dbDriver = dbDriver;
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        _parentForm.SelectView(BaseForm.ViewType.User);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        _parentForm.SelectView(BaseForm.ViewType.Language);
    }
}