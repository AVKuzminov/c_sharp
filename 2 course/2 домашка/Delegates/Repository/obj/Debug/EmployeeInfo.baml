   M S B A M L   `   `   `  ����E  ARepository, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Repository
Repository  5   	       Repository.EmployeeInfo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Repository     5   	     � Title$  Fill in employee data��5   	   $	��300��6'   $	��300��64    � 
ResizeMode$ NoResize=�6@    � WindowStartupLocation$ CenterOwner=�6V   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      .+�5   
   �� $��Center=�6   $��Right=�6/   $��0,0,5,0q�6K   Name6b   �� 5   
   -   5        $��textBoxName��5      $��1��6%   $��25��65   $	��2 3q�6A   �� 5   
   $��1��6   $��Center=�6!   $��Right=�6<   $��0,0,5,0q�6X   	Birthdate6t   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePickerBirthDate��5      $��1��60   $��25��6=   $	��2 3q�6I   $��1��6V   �� 5   
   $��Center=�6   $��2��6/   $��Right=�6<   $��0,0,5,0q�6X   
Department6u   �� 5   
   -   5        $��textBoxDepartment��5      $��2��6+   $��1��68   $��25��6H   $	��2 3q�6T   �� 5   
   $��3��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Bottom=�5      $��Center=�60   .+�5      �� -   5        $��buttonOK��5      $��25��6%   $	��100��61   $��5q�6=   .��6_   OK6c   �� 5      -   5        $��buttonCancel��5      $��25��6)   $	��100��65   $��5q�6A   .��6g   Cancel6o   5      5       5!      