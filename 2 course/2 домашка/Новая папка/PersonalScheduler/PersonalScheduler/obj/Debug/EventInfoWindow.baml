   M S B A M L   `   `   `  ����L  HPersonalScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PersonalSchedulerPersonalScheduler  5   	   '    !PersonalScheduler.EventInfoWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PersonalScheduler     5   	     � Title$  	New event��5   	   $	��450��6   $	��500��6(   $��	Helvetica)�64   $��16(�6K    � 
ResizeMode$ NoResize=�5	   	    � Icon$ Icons/tooltip.ico��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��5q�6   Name6%   �� 5   
   $��5q�6   $��1��6   $��Center=�6,   Date6M   �� 5   
   $��5q�6   $��2��6   Time62   �� 5   
   $��5q�6   $��3��6   Description69   �� 5    
   $��5q�6   $��4��6   Place63   �� 5!   
   -   5         ��Name$ textBlockEmail��5!      $��10,15,197,91q�6,   $��6��6C   $��1��6P   $y�Hidden=�6`   Enter your email6�   �� 5"   
   -   5        $ textBlockPassword��5"      $��1��6/   $
��Left=�6?   $��	10,55,0,0q�6Z   $��6��6m   $
��Wrap=�6z   $	��Top=�6�   $��35��6�   $y�Hidden=�6�   Enter your password6�   �� 5#   
   -   5        $��textBoxName��5#   *   $��3q�6   $��25��6   $��1��6=   (  "System.Windows.Controls.DatePicker  5$   
   -   5        $��
datePicker��5$   !   $��25��6    J� 	AllowDrop .  $��3q�6E   $��1��6P   $��1��6]   �� 5%   
   -   5        $��textBoxTime��5%   )   $��3q�6   $��25��6   $��2��6<   $��1��6I   6}   �� 5'   
   -   5        $��textBoxDescription��5'      $��3q�6,   $��3��67   $��1��6D    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6i   $��80��5(      �� 5*   
   -   5        $��textBoxPlace��5*      $��25��6&   $��3q�63   $��4��6>   $��1��6K   6]   �� 5+   
   -   5        $��textBoxEmail��5+      $��6��6(   $��1��65   $��170,15,30,91q�6E   $y�Hidden=�6[   �� 5,   
   -	   5        $��textBoxPassword��5,      $��6��6+   $��1��68   $��170,50,30,56q�6H   $y�Hidden=�6^   �� 5-   
   -
   5        $��stackPanelRepetition��5-   A   $��5q�6   $��5��6    $��2��6-   	 �� Orientation$	 
Horizontal=�6]   .+�5.      �� -   5        $��checkBoxRepeat��5.      
 d� 	IsChecked$
 FalseY�6-   $��Center=�5/   <   .��6W   Repeat every6e   �� 50      -   5        $��textBoxRepeat��50   $   $
��10 0q�6   {�.  $��50��6K   6X   �� 51      -   5        $��comboBoxUnits��51      $	��150��6,   {�.  @�52      �� 53       �� 
IsSelected . .��65   	minute(s)6@   �� 54      .��6#   	hour(s)6,   �� 55      .��6#   day(s)6+   57      58      �� 5:   
   -   5        $��stackPanelNotifications��5:   -   $��5q�6   $��6��6    .+�5;      �� $	��0 4q�6   Choose notifications:6<   �� 5<      -   5        $��checkBoxVisual��5<      .��6-   Visual65   �� 5=      -   5        $��checkBoxSound��5=      .��6,   Sound63   �� 5>      -   5        $��checkBoxEmail��5>      .��6p   Email6w   5?      �� 5A   
   $��7��6   $��2��6"   $	 
Horizontal=�66   $��Center=�6O   .+�5B      �� -   5        $��buttonOK��5B      $��5q�6%   $	��100��60   $��25��6<   .��6_   OK6c   �� 5C      -   5        $��buttonCancel��5C      $��5q�6)   $	��100��64   $��25��6@   .��6g   Cancel6o   5D      �� 5E   
   -   5        $ textBlockSenderEmail��5E      $��1��62   $
��Left=�6B   $��	10,90,0,0q�6]   $��6��6p   $
��Wrap=�6}   $	��Top=�6�   $��35��6�   $	��144��6�   $y�Hidden=�6�   �� 6�   $�Enter sender email��6�   6�   �� 5F   
   -   5         ��Name$ textBoxSenderEmail��5F      $��6��60   $��1��6=   $��170,85,30,21q�6M   $y�Hidden=�6c   5H      5I      