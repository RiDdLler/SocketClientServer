   M S B A M L   `   `   `  ����  SocketClientHW    SocketClientHW.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Клиент��5   	   $	��350��6   $	��500��6%   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   �� $��0��6   $��Статус:��6!   $��10q�60   �� 5   
   -   5         ��Name$ StatusTextBlock��5      $��0��6-   $��52,10,10,10q�6:   �� 5   
   $��1��6   $��0��6(   $��2��68   $��10q�6L   .u�5      �� -   5         ��Name$ RequestTextBox��5      $��Center=�6.   $��
0,20,0,-19q�6P   .��6d   ��5      `� 5       �� StringFormat$	 {0}��6#   .1�5      ��  �� Path$
 Text�6"    �� ElementName$ RequestTextBox��6.   �� 5      $	 Tag�6"    �� RelativeSource 6-   �� *Self+5      .��5       
 � Tag$! Введите запрос��5   :   .��5      5      �� 5   
   -   5        $��Отправить��5      $��2��6>   $��0��6K   $��10,217,10,10q�6[   �� 5   
   -   5        $ ResponseTextBox��5      $��2��6+   $��10,20,10,39q�68   "	 �� VerticalScrollBarVisibility$
	 Auto=�6M   
 �� 
IsReadOnly
 . 5      5      5       