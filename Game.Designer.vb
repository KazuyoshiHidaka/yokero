﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GamePage
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Player = New PictureBox()
        Panel_Info = New Panel()
        ProgressBar_Stage_Time = New ProgressBar()
        Panel_Player_HP = New FlowLayoutPanel()
        Img_HP_1 = New PictureBox()
        Img_HP_2 = New PictureBox()
        Img_HP_3 = New PictureBox()
        Panel_Game = New Panel()
        Panel_Enemy = New Panel()
        Label_Stage_Clear = New Label()
        Main_Timer = New Timer(components)
        Label1 = New Label()
        Label2 = New Label()
        Panel_Pause = New Panel()
        Panel_Game_Over = New Panel()
        Label5 = New Label()
        Label3 = New Label()
        Timer_Game_Over = New Timer(components)
        CType(Player, ComponentModel.ISupportInitialize).BeginInit()
        Panel_Info.SuspendLayout()
        Panel_Player_HP.SuspendLayout()
        CType(Img_HP_1, ComponentModel.ISupportInitialize).BeginInit()
        CType(Img_HP_2, ComponentModel.ISupportInitialize).BeginInit()
        CType(Img_HP_3, ComponentModel.ISupportInitialize).BeginInit()
        Panel_Game.SuspendLayout()
        Panel_Pause.SuspendLayout()
        Panel_Game_Over.SuspendLayout()
        SuspendLayout()
        ' 
        ' Player
        ' 
        Player.BackColor = Color.Transparent
        Player.BorderStyle = BorderStyle.FixedSingle
        Player.Image = My.Resources.Resources.player
        Player.Location = New Point(385, 473)
        Player.Name = "Player"
        Player.Size = New Size(40, 43)
        Player.SizeMode = PictureBoxSizeMode.StretchImage
        Player.TabIndex = 1
        Player.TabStop = False
        ' 
        ' Panel_Info
        ' 
        Panel_Info.Controls.Add(ProgressBar_Stage_Time)
        Panel_Info.Controls.Add(Panel_Player_HP)
        Panel_Info.Location = New Point(0, 600)
        Panel_Info.Name = "Panel_Info"
        Panel_Info.Size = New Size(800, 150)
        Panel_Info.TabIndex = 2
        ' 
        ' ProgressBar_Stage_Time
        ' 
        ProgressBar_Stage_Time.Location = New Point(538, 53)
        ProgressBar_Stage_Time.Name = "ProgressBar_Stage_Time"
        ProgressBar_Stage_Time.Size = New Size(221, 34)
        ProgressBar_Stage_Time.TabIndex = 1
        ProgressBar_Stage_Time.Value = 50
        ' 
        ' Panel_Player_HP
        ' 
        Panel_Player_HP.AutoSize = True
        Panel_Player_HP.BorderStyle = BorderStyle.FixedSingle
        Panel_Player_HP.Controls.Add(Img_HP_1)
        Panel_Player_HP.Controls.Add(Img_HP_2)
        Panel_Player_HP.Controls.Add(Img_HP_3)
        Panel_Player_HP.Location = New Point(323, 36)
        Panel_Player_HP.Name = "Panel_Player_HP"
        Panel_Player_HP.Size = New Size(158, 55)
        Panel_Player_HP.TabIndex = 0
        ' 
        ' Img_HP_1
        ' 
        Img_HP_1.Image = My.Resources.Resources.heart
        Img_HP_1.InitialImage = My.Resources.Resources.fire_ball
        Img_HP_1.Location = New Point(3, 3)
        Img_HP_1.Name = "Img_HP_1"
        Img_HP_1.Size = New Size(45, 47)
        Img_HP_1.SizeMode = PictureBoxSizeMode.StretchImage
        Img_HP_1.TabIndex = 0
        Img_HP_1.TabStop = False
        ' 
        ' Img_HP_2
        ' 
        Img_HP_2.Image = My.Resources.Resources.heart
        Img_HP_2.Location = New Point(54, 3)
        Img_HP_2.Name = "Img_HP_2"
        Img_HP_2.Size = New Size(45, 47)
        Img_HP_2.SizeMode = PictureBoxSizeMode.StretchImage
        Img_HP_2.TabIndex = 1
        Img_HP_2.TabStop = False
        ' 
        ' Img_HP_3
        ' 
        Img_HP_3.Image = My.Resources.Resources.heart
        Img_HP_3.Location = New Point(105, 3)
        Img_HP_3.Name = "Img_HP_3"
        Img_HP_3.Size = New Size(45, 47)
        Img_HP_3.SizeMode = PictureBoxSizeMode.StretchImage
        Img_HP_3.TabIndex = 2
        Img_HP_3.TabStop = False
        ' 
        ' Panel_Game
        ' 
        Panel_Game.BackColor = Color.FromArgb(CByte(64), CByte(0), CByte(0))
        Panel_Game.BorderStyle = BorderStyle.FixedSingle
        Panel_Game.Controls.Add(Player)
        Panel_Game.Controls.Add(Panel_Enemy)
        Panel_Game.Controls.Add(Label_Stage_Clear)
        Panel_Game.ForeColor = Color.Black
        Panel_Game.Location = New Point(0, 0)
        Panel_Game.Name = "Panel_Game"
        Panel_Game.Size = New Size(800, 600)
        Panel_Game.TabIndex = 3
        ' 
        ' Panel_Enemy
        ' 
        Panel_Enemy.BackColor = Color.Transparent
        Panel_Enemy.ForeColor = Color.Black
        Panel_Enemy.Location = New Point(0, 0)
        Panel_Enemy.Name = "Panel_Enemy"
        Panel_Enemy.Size = New Size(800, 600)
        Panel_Enemy.TabIndex = 1
        ' 
        ' Label_Stage_Clear
        ' 
        Label_Stage_Clear.AutoSize = True
        Label_Stage_Clear.BackColor = Color.Transparent
        Label_Stage_Clear.Font = New Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        Label_Stage_Clear.ForeColor = Color.White
        Label_Stage_Clear.Location = New Point(286, 150)
        Label_Stage_Clear.Name = "Label_Stage_Clear"
        Label_Stage_Clear.Size = New Size(249, 48)
        Label_Stage_Clear.TabIndex = 0
        Label_Stage_Clear.Text = "ステージクリア！"
        Label_Stage_Clear.Visible = False
        ' 
        ' Main_Timer
        ' 
        Main_Timer.Enabled = True
        Main_Timer.Interval = 13
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(358, 173)
        Label1.Name = "Label1"
        Label1.Size = New Size(105, 48)
        Label1.TabIndex = 0
        Label1.Text = "ポーズ"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(338, 262)
        Label2.Name = "Label2"
        Label2.Size = New Size(147, 32)
        Label2.TabIndex = 1
        Label2.Text = "Escキーで再開"
        ' 
        ' Panel_Pause
        ' 
        Panel_Pause.BackColor = SystemColors.WindowFrame
        Panel_Pause.Controls.Add(Label2)
        Panel_Pause.Controls.Add(Label1)
        Panel_Pause.Location = New Point(0, 0)
        Panel_Pause.Name = "Panel_Pause"
        Panel_Pause.Size = New Size(800, 750)
        Panel_Pause.TabIndex = 0
        ' 
        ' Panel_Game_Over
        ' 
        Panel_Game_Over.BackColor = Color.Black
        Panel_Game_Over.Controls.Add(Label5)
        Panel_Game_Over.Controls.Add(Label3)
        Panel_Game_Over.Location = New Point(0, 0)
        Panel_Game_Over.Name = "Panel_Game_Over"
        Panel_Game_Over.Size = New Size(800, 750)
        Panel_Game_Over.TabIndex = 0
        Panel_Game_Over.Visible = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(306, 288)
        Label5.Name = "Label5"
        Label5.Size = New Size(198, 32)
        Label5.TabIndex = 2
        Label5.Text = "諦めるのはまだ早い"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial Black", 18F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(287, 170)
        Label3.Name = "Label3"
        Label3.Size = New Size(239, 51)
        Label3.TabIndex = 0
        Label3.Text = "Game Over"
        ' 
        ' Timer_Game_Over
        ' 
        Timer_Game_Over.Interval = 13
        ' 
        ' GamePage
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel_Game)
        Controls.Add(Panel_Info)
        Controls.Add(Panel_Pause)
        Controls.Add(Panel_Game_Over)
        Name = "GamePage"
        Size = New Size(800, 750)
        CType(Player, ComponentModel.ISupportInitialize).EndInit()
        Panel_Info.ResumeLayout(False)
        Panel_Info.PerformLayout()
        Panel_Player_HP.ResumeLayout(False)
        CType(Img_HP_1, ComponentModel.ISupportInitialize).EndInit()
        CType(Img_HP_2, ComponentModel.ISupportInitialize).EndInit()
        CType(Img_HP_3, ComponentModel.ISupportInitialize).EndInit()
        Panel_Game.ResumeLayout(False)
        Panel_Game.PerformLayout()
        Panel_Pause.ResumeLayout(False)
        Panel_Pause.PerformLayout()
        Panel_Game_Over.ResumeLayout(False)
        Panel_Game_Over.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Player As PictureBox
    Friend WithEvents Panel_Info As Panel
    Friend WithEvents Panel_Player_HP As FlowLayoutPanel
    Friend WithEvents Img_HP_1 As PictureBox
    Friend WithEvents Img_HP_2 As PictureBox
    Friend WithEvents Img_HP_3 As PictureBox
    Friend WithEvents Panel_Game As Panel
    Friend WithEvents Panel_Enemy As Panel
    Friend WithEvents Main_Timer As Timer
    Friend WithEvents Label_Stage_Clear As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel_Pause As Panel
    Friend WithEvents Panel_Game_Over As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ProgressBar_Stage_Time As ProgressBar
    Friend WithEvents Timer_Game_Over As Timer
End Class
