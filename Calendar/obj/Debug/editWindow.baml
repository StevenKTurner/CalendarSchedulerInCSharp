   M S B A M L   `   `   `  ����C  ?Calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CalendarCalendar  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       Calendar.editWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Calendar     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   -   5          � Title$  
editWindow��5	   	   $	��300��6   $	��300��6)   .��5
      � .+�5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ 
datePicker��5      $
��Left=�6)   $��	10,10,0,0q�6D   $	��Top=�6W      SelectedDateFormat$
 Long=�6o   �� 5   
   -   5         ��Name$ timeEntryLabel��5      $��Time: ��6(   $
��Left=�69   $��	10,39,0,0q�6T   $	��Top=�6g   �� 5   
   -   5        $ nameEntryLabel��5      $��Event Name: ��6(   $
��Left=�6?   $��	14,70,0,0q�6Z   $	��Top=�6m   �� 5   
   -   5        $ noteEntryLabel��5      $��Notes:��6(   $
��Left=�69   $��
14,101,0,0q�6T   $	��Top=�6h   �� 5   
   -   5         ��Name$ 	nameEntry��5      $
��Left=�6%   $��23��6@   $��	99,74,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��183��6�    �� 	MaxLength$ 20��6�    �� MaxLines$ 1��6�   �� 5   
   -   5        $ 	noteEntry��5      $
��Left=�6%   $	��100��6@   $��
63,113,0,0q�6M   $	��Top=�6a   $	��219��6y   $	 100��6�   �� 5   
   -   5         ��Name$ 
saveButton��5      $
��Save��6%   $
��Left=�64   $��207,239,0,0q�6O   $	��Top=�6d   $��75��6|   6�   �� 5   
   -	   5        $ cancelButton��5      $��Cancel��6'   $
��Left=�68   $��
10,239,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -
   5        	 ��Name$	 ampmSelecter��5      $
��Left=�6)   $��
131,43,0,0q�6D   $	��Top=�6X   $��56��6p   
 �� SelectedIndex$
 0��6{    �� 
IsReadOnly . .@�5      ��AM��6    ��5      PM��6    5      �� 5   
   -   5        $ 	hourEntry��5      $
��Left=�6%   $��23��6@   $��	57,42,0,0q�6L   $
 Wrap=�6_   $	��Top=�6s   $��28��6�   �� 5   
   -   5        $ minuteEntry��5      $
��Left=�6'   $��23��6B   $��	99,42,0,0q�6N   $
 Wrap=�6a   $	��Top=�6u   $��27��6�   �� 5   
   -   5        $ label��5      $��:��6   $
��Left=�6+   $��	85,39,0,0q�6F   $	��Top=�6Y   5      5      