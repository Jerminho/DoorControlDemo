   M S B A M L   `   `   `  ����J  FDoorControlDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:DoorControlDemo.ViewModelsDoorControlDemo.ViewModels  5   	   *    $DoorControlDemo.Views.CreateUserView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:DoorControlDemo.ViewModels     5   	     � Title$  CreateUserView��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
   �� $��170,74,178,111q�6   $	��NaN��6-   $	��NaN��6:   .+�5      �� $��Create User��6   $��16(�6+   $
��Bold"�69   $��0,0,0,10q�6K   $��Center=�6]   �� 5      $��	User Name��6   $��11(�6)   $
��Bold"�67   $��0,0,0,10q�6I   �� 5      -   5         ��Name$ UserNameTextBox��5      $��0,0,0,10q�6I   ��6/   �� *
UserName+6I   �� 5      $��Email��6   $��11(�6%   $
��Bold"�63   $��0,0,0,10q�6E   �� 5      -   5        $ UserMailTextBox��5      $��0,0,0,10q�6I   ��6/   �� *
UserMail+6I   �� 5      $��Phone number��6   $��11(�6,   $
��Bold"�6:   $��0,0,0,10q�6L   �� 5      -   5        $ UserPhoneNumberTextBox��5      $��0,0,0,10q�6W   ��66   �� *UserPhoneNumber+6W   �� 5      $��Create User��6   ��6+   �� *CreateUserCommand+5      �� 5   
   -   5         ��Name$ btnCreateMain��5      $
��Home��6(   $
��Left=�67   $��152,315,0,0q�6R   $	��Top=�6g   $��30��6   $	��100��6�   ��6�   �� *CreateMainCommand+�� 5   
   -   5        $ btnNavigateToAssignBadge��5      $��ASSIGN��63   $
��Left=�6D   $��522,315,0,0q�6_   $	��Top=�6t   $��30��6�   $	��100��6�   ��6�   �� *NavigateToAssignBadgeCommand+5      5      