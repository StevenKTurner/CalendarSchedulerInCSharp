   M S B A M L   `   `   `  ����C  ?Calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CalendarCalendar  5   	       Calendar.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Calendar     5   	   -   5          �Name$
  main��5   	    � Title$ 
MainWindow��5   	   $	��700��6   $	��300��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ addEventButton��5
      $��	Add Event��6)   $
��Left=�6=   $��207,639,0,0q�6X   $	��Top=�6m   $��75��6�   6�   �� 5   
   $
��Left=�6   $	��452��62   $��
10,182,0,0q�6?   $	��Top=�6S   $	��272��6k   $
��Auto=�6w   .��5      �� -   5         ��Name$ 	eventView��5      5      �� 5   
   $
��Left=�6   $��74��62   $��	10,72,0,0q�6>   $	��Top=�6Q   $	��272��6i   $
��Auto=�6u   .��5      �� -   5        $ dueListView��5      5      �� 5   
   -   5         ��Name$ dueEventListLabel��5      $��	Due Soon:��6+   $
��Left=�6?   $��	10,41,0,0q�6Z   $	��Top=�6m   �� 5   
   -   5        $ eventViewLabel��5      $��Dates and Events:��6(   $
��Left=�6D   $��
10,151,0,0q�6_   $	��Top=�6s   �� 5   
   -   5        $ printButton��5      $��Print Report��6&   $
��Left=�6=   $��
10,639,0,0q�6X   $	��Top=�6l   $��75��6�   6�   �� 5   
   -   5        $ 	timeLabel��5      $��
Right Now:��6#   $
��Left=�68   $��	10,10,0,0q�6S   $	��Top=�6f   �� 5   
   -	   5         ��Name$ timeView��5      $
��Left=�6&   $��	87,15,0,0q�6A   $
��Wrap=�6T   $
��Time��6h   $	��Top=�6t   $��16(�6�   5      5      