   M S B A M L   `   `   `  ����>  :hw2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:hw2hw2  5   	       hw2.TerminalsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:hw2     5   	     � Title$  Terminals window��5   	   $	��384��6"   $	��683��6/   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF78F3FF��6   � 5      $ 	#FFB900FF��6    � Offset$ 1Q�61   5       � RowDefinitions 5   
   �� 5      $
��0.5* �6   6,   �� 5      $
��0.5* �6   6,   �� 5      $
��0.5* �6   6,   �� 5      $
��0.5* �6   6,   �� 5      $
��3.5* �6   6,   �� 5      $
��0.5* �6   6,    � ColumnDefinitions 5   
   �� 5      $
��0.2* �6   6.   �� 5      $��1* �6   6,   �� 5      $
��0.2* �6   6.   �� 5      $��1* �6   6,   �� 5      $
��0.2* �6   6.   �� 5      $��1* �6   6,   �� 5      $	��0.2 �6   6-   �� 5       $
��0.2* �6   6.   .+�5"   
   �� -   5         ��Name$ comboBox��5"      $��2��6%   $��1��62   ���	#FF0DE6B5 J� OpacityMask �	#FF0DE6B5.@�5#      �� ���	#FFCD00FB
�������Add6G   �� 5$      ���	#FFCD00FB
�������Edit6H   �� 5%      ���	#FFCD00FB
�������First query6O   �� 5&      ���	#FFCD00FB
�������Second query6P   5'      �� 5(   
   -   5        	 ��Name$	 LocationLabel��5(      $��Enter location data��6'   $��1��6E   $��3��6R   ���	#FFCD00FB
�������6y   �� 5)   
   -   5        
 ��Name$
 LocationTextBox��5)      $��2��6+   $��3��68   ���	#FF99FBFF6H   �� 5*   
   -   5         ��Name$ ExecuteButton��5*      $��Execute��6(   $��2��6:   $��5��6G   ���	#FFCD00FB
�������6�   &   System.Windows.Controls.DataGrid  5+   
   -   5          Name$ TerminalsDataGrid��5+         CanUserAddRows .  $��4��6E   $��1��6R   $��1��6c   $��5��6s   ���	#FFCD00FB���	#FF99FBFF6�   (  "System.Windows.Controls.DatePicker  5,   
   -   5          Name$ 
datePicker��5,      $��1��6)   $��5��66   ���	#FF99FBFF6F   5-      5.      