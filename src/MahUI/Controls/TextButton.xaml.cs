using System.Windows.Input;

namespace MahUI.Controls;

public partial class TextButton : ContentView
{
    public event EventHandler OnButtonClicked;
    private Color _originColor;
    private ICommand _originCommand;
    public TextButton()
    {
        InitializeComponent();
        if (_originColor is null)
        {
            _originColor = Colors.SkyBlue;
        }
    }

    #region Text Property

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        defaultValue: "TEXT",
        declaringType: typeof(TextButton),
        defaultBindingMode: BindingMode.OneWay
        );

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set { SetValue(TextProperty, value); }
    }
    #endregion

    #region Size Property

    public static readonly BindableProperty SizeProperty = BindableProperty.Create(
        propertyName: nameof(Size),
        returnType: typeof(double),
        defaultValue: (double)16,
        declaringType: typeof(TextButton),
        defaultBindingMode: BindingMode.OneWay
        );

    public double Size
    {
        get => (double)GetValue(SizeProperty);
        set { SetValue(SizeProperty, value); }
    }
    #endregion

    #region TextColor Property
    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
        propertyName: nameof(TextColor),
        returnType: typeof(Color),
        defaultValue: Colors.SkyBlue,
        declaringType: typeof(TextButton),
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnTextColorPropertyChanged
        );
    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set
        {
            SetValue(TextColorProperty, value);
        }
    }

    private static void OnTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is TextButton textButton)
        {
            Color color = (Color)newValue;
            if (color != Colors.Gray)
            {
                textButton._originColor = color;
            }
        }
    }

    #endregion

    #region Disabled Property

    public static readonly BindableProperty DisabledProperty = BindableProperty.Create(
        propertyName: nameof(Disabled),
        returnType: typeof(bool),
        defaultValue: false,
        declaringType: typeof(TextButton),
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnDisabledPropertyChanged
    );

    public bool Disabled
    {
        get => (bool)GetValue(DisabledProperty);
        set { SetValue(DisabledProperty, value); }
    }

    private static void OnDisabledPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is TextButton textButton)
        {
            bool isDisabled = (bool)newValue;
            if (isDisabled)
            {
                textButton.TextColor = Colors.Gray;
                textButton.Command = null;
            }
            else
            {
                textButton.TextColor = textButton._originColor;
                textButton.Command = textButton._originCommand;
            }
        }
    }

    #endregion

    #region Command Property

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        propertyName: nameof(Command),
        returnType: typeof(ICommand),
        defaultValue: null,
        declaringType: typeof(TextButton),
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnCommandColorPropertyChanged
    );

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set
        {
            SetValue(CommandProperty, value);
        }
    }

    private static void OnCommandColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is TextButton textButton)
        {
            ICommand command = (ICommand)newValue;
            if (command != null)
            {
                textButton._originCommand = command;
            }
        }
    }

    #endregion

    #region StartIcon Property

    public static readonly BindableProperty StartIconProperty = BindableProperty.Create(
        propertyName: nameof(StartIcon),
        returnType: typeof(string),
        defaultValue: string.Empty,
        declaringType: typeof(TextButton),
        defaultBindingMode: BindingMode.OneWay
    );

    public string StartIcon
    {
        get => (string)GetValue(StartIconProperty);
        set { SetValue(StartIconProperty, value); }
    }

    #endregion

    #region EndIcon Property

    public static readonly BindableProperty EndIconProperty = BindableProperty.Create(
        propertyName: nameof(EndIcon),
        returnType: typeof(string),
        defaultValue: string.Empty,
        declaringType: typeof(TextButton),
        defaultBindingMode: BindingMode.OneWay
    );

    public string EndIcon
    {
        get => (string)GetValue(EndIconProperty);
        set { SetValue(EndIconProperty, value); }
    }

    #endregion

    private void Clicked(object sender, EventArgs e)
    {
        if (!Disabled)
        {
            OnButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}