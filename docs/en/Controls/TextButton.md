# TextButton

Buttons allow users to take actions, and make choices, with a single tap.
Text buttons are typically used for less-pronounced actions, including those located: in dialogs, in cards. In cards, text buttons help maintain an emphasis on card content.

<div align="center">
<img align="center" src=https://i.ibb.co/7RbpCHN/Control-V-8.png />
</div>

## Package

To run tests, run the following command

```bash
  dotnet add package MahUI
```

## Handling clicks
TextButton accepts an OnButtonClicked Event when clicking the button

```xaml
    xmlns:mahui="clr-namespace:MahUI.Controls;assembly=MahUI"
    <mahui:TextButton OnButtonClicked="{_YOUR_EVENT_HANDLER_NAME}" />
```

## Attributes
🔵 Text - the text that is written on the button #string

🔵 TextColor - the color of the text on the button #Color

🔵 Size - height of the button #double

🔵 Disabled - disables button functionality #bool

🔵 Command - the command to execute when clicked #ICommand

🔴 StartIcon - the command to execute when clicked (work only Image) #string

🔴 EndIcon - the command to execute when clicked (work only Image) #string








