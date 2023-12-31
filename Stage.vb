﻿
Imports System.Media
Imports System.Numerics

Public MustInherit Class Stage

    'ステージごとに、1フレームごとの敵の追加/移動/削除を行う
    '衝突処理は別の所で行うため不要
    '
    '例えば、
    '敵の追加:
    '- ステージ1は、40フレームごとにランダムな位置にFireballを追加
    '- ステージ2は、初めに障害物を設置した後、100フレームごとにWaveを追加
    '
    '敵の移動:
    '- ステージ1は、1フレームごとに全てのFireballを下に移動
    '- ステージ2は、1フレームごとに全てのWaveを下に移動させ、
    '  さらに、100フレームごとに障害物を移動させる
    '
    '敵の削除:
    '- ステージ1は、画面外に出たFireballを削除
    '- ステージ2は、画面外に出たWaveを削除し、
    '  さらに、一定時間で障害物を削除する
    '
    'などステージごとに異なる
    Public MustOverride Sub On_F_Update()

    'ゲーム画面のインスタンス
    MustOverride Property Game As GamePage

    'ステージが開始された時刻
    'ステージが開始されていない場合は Nothing
    MustOverride Property Start_Ftime As Integer?

    'ステージがクリアされた時刻
    'ステージがクリアされていない場合は Nothing
    MustOverride Property Cleared_At As Integer?

    'ステージが開始されたかどうか
    ReadOnly Property Is_Started As Boolean
        Get
            Return Start_Ftime IsNot Nothing
        End Get
    End Property

    'ステージが開始されてからの経過フレーム時間
    ReadOnly Property Ftime As Integer
        Get
            Return Game.ftime - Start_Ftime
        End Get
    End Property

    'ステージがクリアされたかどうか
    ReadOnly Property Is_Cleared As Boolean
        Get
            Return Cleared_At IsNot Nothing
        End Get
    End Property

    'ステージを開始する時の処理
    Overridable Sub Start(_game_page As GamePage)
        Game = _game_page
        Start_Ftime = _game_page.ftime
    End Sub

    'ステージクリアした時の処理
    Overridable Sub Clear()
        Cleared_At = Game.ftime
    End Sub
End Class

Public Class Stage1
    Inherits Stage

    '===========================================================
    'ステージ1 固有
    '===========================================================

    ReadOnly Property Fireball_Speed As Integer 'Fireballの速度
        Get
            Return Game.Rh(10)
        End Get
    End Property
    Dim ftime_to_mid As Integer = 1000 '開始から中間イベントまでの時間

    'TopPageのステージ選択ボタンの背景色にも使われる
    Public Shared bg_color As Color = Color.FromArgb(255, 64, 0, 0)

    '1つの Column の横幅
    Private ReadOnly Property Col_Width As Double
        Get
            Return Game.Panel_Game.Width / 9
        End Get
    End Property

    'ステージ１固有の開始処理
    Public Overrides Sub Start(_game_page As GamePage)
        MyBase.Start(_game_page)

        '見た目を設定
        Game.Panel_Game.BackColor = bg_color

        '中間イベントまでのプログレスバーの設定
        Game.ProgressBar_Stage_Time.Maximum = ftime_to_mid
        Game.ProgressBar_Stage_Time.Value = ftime_to_mid
        Game.ProgressBar_Stage_Time.Minimum = 0
    End Sub

    'ステージ１固有のクリア処理
    Public Overrides Sub Clear()
        MyBase.Clear()

        'Fireballを全て削除
        Game.Panel_Enemy.Controls.Clear()
    End Sub

    '1フレームごとのプログレスバーの更新
    Public Sub F_Update_ProgressBar()
        Game.ProgressBar_Stage_Time.Value =
            Math.Max(Game.ProgressBar_Stage_Time.Value - 1, 0)
    End Sub


    '1フレームごとに、敵の追加、移動、削除を行う
    '衝突処理は別の所で行うため不要

    Public Overrides Sub On_F_Update()
        If Not Is_Started Or Is_Cleared Then
            Return
        End If

        '既存のEnemyの更新処理
        For Each _enemy In Game.Panel_Enemy.Controls
            Dim enemy As Enemy = DirectCast(_enemy, Enemy)
            enemy.On_F_Update()
        Next

        '残り時間を示すプログレスバーの更新
        F_Update_ProgressBar()

        'ステージ1の流れ
        '
        '基本:
        '弱/中/強のFireballをランダムな位置に出現させる
        '
        '半分経過したとき:
        '手動で階段状にFireballを出現させる
        '

        If Ftime >= ftime_to_mid Then
            '中間イベント

            Dim spawn_fspan = 19 '中間より前とは異なる間隔でFireballを生成するため
            Dim time = Ftime - ftime_to_mid '中間イベントが始まった時刻

            If time = 0 Then
                '中間イベント中のプログレスバー初期化
                Game.ProgressBar_Stage_Time.Maximum = spawn_fspan * 45
                Game.ProgressBar_Stage_Time.Value = spawn_fspan * 45
            End If

            'まず、左から右に階段状で生成 ->
            If time = 0 Then
                Spawn_Fireball_In_Col(0)
            ElseIf time = spawn_fspan Then
                Spawn_Fireball_In_Col(1)
            ElseIf time = spawn_fspan * 2 Then
                Spawn_Fireball_In_Col(2)
            ElseIf time = spawn_fspan * 3 Then
                Spawn_Fireball_In_Col(3)
            ElseIf time = spawn_fspan * 4 Then
                Spawn_Fireball_In_Col(4)
            ElseIf time = spawn_fspan * 5 Then
                Spawn_Fireball_In_Col(5)
            ElseIf time = spawn_fspan * 6 Then
                Spawn_Fireball_In_Col(6)
            ElseIf time = spawn_fspan * 7 Then
                Spawn_Fireball_In_Col(7)
            ElseIf time = spawn_fspan * 8 Then
                '右端を空ける

                '次は、右から左に階段状で生成 <-
            ElseIf time = spawn_fspan * 9 Then
                Spawn_Fireball_In_Col(8)
            ElseIf time = spawn_fspan * 10 Then
                Spawn_Fireball_In_Col(7)
            ElseIf time = spawn_fspan * 11 Then
                Spawn_Fireball_In_Col(6)
            ElseIf time = spawn_fspan * 12 Then
                Spawn_Fireball_In_Col(5)
            ElseIf time = spawn_fspan * 13 Then
                Spawn_Fireball_In_Col(4)
            ElseIf time = spawn_fspan * 14 Then
                Spawn_Fireball_In_Col(3)
            ElseIf time = spawn_fspan * 15 Then
                Spawn_Fireball_In_Col(2)
            ElseIf time = spawn_fspan * 16 Then
                Spawn_Fireball_In_Col(1)
            ElseIf time = spawn_fspan * 17 Then
                '左端を空ける

                '次は、左右から中央に向かって階段状で生成 -> <-
            ElseIf time = spawn_fspan * 18 Then
                Spawn_Fireball_In_Col(0)
                Spawn_Fireball_In_Col(8)
            ElseIf time = spawn_fspan * 19 Then
                Spawn_Fireball_In_Col(1)
                Spawn_Fireball_In_Col(7)
            ElseIf time = spawn_fspan * 20 Then
                Spawn_Fireball_In_Col(2)
                Spawn_Fireball_In_Col(6)
            ElseIf time = spawn_fspan * 21 Then
                Spawn_Fireball_In_Col(3)
                Spawn_Fireball_In_Col(5)
            ElseIf time = spawn_fspan * 22 Then
                '中央を空ける

                '次は、中央から左右に向かって階段状で生成 <- ->
            ElseIf time = spawn_fspan * 23 Then
                Spawn_Fireball_In_Col(4)
            ElseIf time = spawn_fspan * 24 Then
                Spawn_Fireball_In_Col(3)
                Spawn_Fireball_In_Col(5)
            ElseIf time = spawn_fspan * 25 Then
                Spawn_Fireball_In_Col(2)
                Spawn_Fireball_In_Col(6)
            ElseIf time = spawn_fspan * 26 Then
                Spawn_Fireball_In_Col(1)
                Spawn_Fireball_In_Col(7)
            ElseIf time = spawn_fspan * 27 Then
                '左右を空ける

                '次は、左右から中央に向かって階段状で生成 -> <-
            ElseIf time = spawn_fspan * 28 Then
                Spawn_Fireball_In_Col(0)
                Spawn_Fireball_In_Col(8)
            ElseIf time = spawn_fspan * 29 Then
                Spawn_Fireball_In_Col(1)
                Spawn_Fireball_In_Col(7)
            ElseIf time = spawn_fspan * 30 Then
                Spawn_Fireball_In_Col(2)
                Spawn_Fireball_In_Col(6)
            ElseIf time = spawn_fspan * 31 Then
                Spawn_Fireball_In_Col(3)
                Spawn_Fireball_In_Col(5)
            ElseIf time = spawn_fspan * 32 Then
                '中央を空ける

                '最後に中央に強いFireballを生成
            ElseIf time = spawn_fspan * 35 Then
                Spawn_Last_Fireball()
            ElseIf time >= spawn_fspan * 45 Then
                Clear()
            End If

        Else
            '中間イベントより前のとき

            Dim spawn_fspan As Integer = 30

            If Ftime > 0 And Ftime Mod spawn_fspan * 8 = 0 Then
                '8個のうち1つは強い玉.
                '一番最初に出さないように Ftime > 0 の時のみ.
                Spawn_Fireball_lv3()

            ElseIf Ftime > 0 And Ftime Mod spawn_fspan * 3 = 0 Then
                ''3個のうち1つは中玉.
                '一番最初に出さないように Ftime > 0 の時のみ.
                Spawn_Fireball_lv2()

            ElseIf Ftime Mod spawn_fspan = 0 Then
                '弱玉
                Spawn_Fireball_In_Col(Game.random.Next(9))
            End If
        End If

    End Sub

    '指定した列の中にFireballを出現させる
    '
    'column: 0 ～ 8
    'ゲーム画面を 9列に分割した時に、どの列にFireballを出現させるかを指定する

    'イメージ;
    '| | | | | | | | | |
    '|O| | | | | | | | |
    '| | | | | | |O| | |
    '| | | |O| | | | | |
    '| | | | | | | | |O|
    '| | | | | | | | | |

    Private Function Init_Fireball_In_Col(column As Integer) As Fireball
        Dim width As Integer = Col_Width()

        Dim fireball As New Fireball(Game) With {
            .Size = New Size(width, width),
            .Location = New Point(Col_Width() * column, 0),
            .speed = Fireball_Speed
        }
        Return fireball
    End Function

    '毎度 Init -> Controls.Add するのが面倒なので、一つにまとめる
    Private Sub Spawn_Fireball_In_Col(column As Integer)
        Dim fireball As Fireball = Init_Fireball_In_Col(column)
        Game.Panel_Enemy.Controls.Add(fireball)
    End Sub

    Private Sub Spawn_Fireball_lv2()
        'プレイヤーがいる列に出現させる
        'プレイヤーの中心がどの列に含まれるかを考えている
        Dim player_center = Game.Player.Left + Game.Player.Width / 2
        Dim col = Math.Floor(player_center / Col_Width())

        Dim fireball As Fireball = Init_Fireball_In_Col(col)
        fireball.speed = Fireball_Speed
        Game.Panel_Enemy.Controls.Add(fireball)
    End Sub

    Private Sub Spawn_Fireball_lv3()
        Dim fireball As New Fireball(Game) With {
                .atk = 2,
                .Size = New Size(Col_Width * 1.5, Col_Width * 1.5),
                .speed = Fireball_Speed
            }
        'プレイヤーの真正面に出現させる
        Dim player_center = Game.Player.Left + Game.Player.Width / 2
        fireball.Left = player_center - fireball.Width / 2
        Game.Panel_Enemy.Controls.Add(fireball)
    End Sub

    '最後に出す特大の玉
    Private Sub Spawn_Last_Fireball()
        Dim fireball As New Fireball(Game) With {
                .atk = 3,
                .Size = New Size(Col_Width * 5, Col_Width * 5),
                .speed = Fireball_Speed
            }
        'プレイヤーの真正面に出現させる
        Dim player_center = Game.Player.Left + Game.Player.Width / 2
        fireball.Top = -fireball.Height
        fireball.Left = player_center - fireball.Width / 2
        Game.Panel_Enemy.Controls.Add(fireball)
    End Sub

    '===========================================================
    'Override
    '===========================================================

    Dim _game_page As GamePage
    Overrides Property Game As GamePage
        Get
            Return _game_page
        End Get
        Set(value As GamePage)
            _game_page = value
        End Set
    End Property

    Dim _start_ftime As Integer?
    Overrides Property Start_Ftime As Integer?
        Get
            Return _start_ftime
        End Get
        Set(value As Integer?)
            _start_ftime = value
        End Set
    End Property

    Dim _cleared_at As Integer?
    Overrides Property Cleared_At As Integer?
        Get
            Return _cleared_at
        End Get
        Set(value As Integer?)
            _cleared_at = value
        End Set
    End Property

End Class


Public Class Stage2
    Inherits Stage

    '===========================================================
    'ステージ2 固有
    '===========================================================

    '画面下側のダメージ領域
    Dim trench As Trench

    'ステージ開始からクリアまでの時間
    Dim duration As Integer = 2500

    '海溝の高さ
    'Dim trench_height As Integer = 50

    ReadOnly Property Trench_Height As Integer
        Get
            Return Game.Rh(100)
        End Get
    End Property

    '背景色
    Public Shared bg_color As Color = Color.FromArgb(255, 0, 0, 128)

    ReadOnly Property Col_Width As Integer
        Get
            Return Game.Panel_Game.Width / 9
        End Get
    End Property

    'ステージ２固有の開始処理
    Public Overrides Sub Start(_game_page As GamePage)
        MyBase.Start(_game_page)

        '見た目を設定
        Game.Panel_Game.BackColor = bg_color

        '残り時間を示すプログレスバーを初期化
        Game.ProgressBar_Stage_Time.Maximum = duration
        Game.ProgressBar_Stage_Time.Value = duration
        Game.ProgressBar_Stage_Time.Minimum = 0

        'ステージの初期オブジェクトを作成
        trench = New Trench(Game) With {
            .Height = 0, 'アニメーションで徐々に高さを増やしていく
            .Top = Game.Panel_Game.Height
        }
        Game.Panel_Enemy.Controls.Add(trench)

        '初見のプレイヤーがいきなりTrenchに落ちないように、
        'プレイヤーのTopを調整する
        Game.Player.Top = trench.Top - Game.Player.Height - Trench_Height - Game.Rh(10)
    End Sub

    'ステージ２固有のクリア処理
    Public Overrides Sub Clear()
        MyBase.Clear()
        Game.Panel_Enemy.Controls.Clear()
    End Sub

    '1フレームごとのプログレスバーの更新
    Public Sub F_Update_ProgressBar()
        Game.ProgressBar_Stage_Time.Value =
            Math.Max(Game.ProgressBar_Stage_Time.Value - 1, 0)
    End Sub

    Public Overrides Sub On_F_Update()
        If Not Is_Started Or Is_Cleared Then
            Return
        End If

        'クリア処理
        If Ftime > duration Then
            Clear()
            Return
        End If

        '既存のEnemyの更新処理
        For Each _enemy In Game.Panel_Enemy.Controls
            Dim enemy As Enemy = DirectCast(_enemy, Enemy)
            enemy.On_F_Update()
        Next

        'プログレスバーの更新
        F_Update_ProgressBar()


        '========== 残り時間に応じて、敵を作成 ==========

        'Waveの出現開始時刻
        Dim start_spawn_ftime As Integer = 150

        '指定したフレームごとにWaveを出現させる
        Dim spawn_fspan As Integer = 80

        If Ftime <= 100 Then
            'まず、Trenchを徐々に広げる
            trench.Height = trench_height * (Ftime / 100)
            trench.Top = Game.Panel_Game.Height - trench.Height
        ElseIf Ftime < start_spawn_ftime Then
            'Trenchのアニメーション終了後、休憩時間

            'まずは手動で、固定のWaveを出現させる
        ElseIf Ftime = start_spawn_ftime Then
            Spawn_Wave(0, 6)

        ElseIf Ftime = start_spawn_ftime + spawn_fspan Then
            Spawn_Wave(0, 3)
            Spawn_Wave(5, 8)

        ElseIf Ftime = start_spawn_ftime + spawn_fspan * 2 Then
            Spawn_Wave(2, 8)

        ElseIf Ftime = start_spawn_ftime + spawn_fspan * 3 Then
            Spawn_Horizontal_Wave()

        ElseIf Ftime > start_spawn_ftime + spawn_fspan * 3 And Ftime < duration Then
            '以降は、ランダムでWaveを出現させる
            If Ftime Mod spawn_fspan * 5 = 0 Then
                Spawn_Horizontal_Wave()

            ElseIf Ftime Mod spawn_fspan * 2 = 0 Then
                '中央波. 出現範囲はランダム
                Spawn_Wave(Game.random.Next(3), Game.random.Next(3) + 5)

            ElseIf Ftime Mod spawn_fspan = 0 Then
                '左右波. 出現範囲はランダム
                Spawn_Wave(0, Game.random.Next(2) + 2)
                Spawn_Wave(Game.random.Next(2) + 5, 8)
            End If
        End If


    End Sub


    'ゲーム画面を 9列に分割したと考え、
    '指定した列から列までの範囲一体のWaveを出現させる
    '
    '_from: 0 ～ 8
    '_to: 0 ～ 8
    Private Function Init_Wave(_from As Integer, _to As Integer) As Wave
        Dim wave As New Wave(Game) With {
            .Size = New Size(Col_Width() * (_to - _from + 1), Game.Panel_Game.Height * 0.13),
            .Location = New Point(Col_Width() * _from, 0),
            .speed = Game.Rh(5 + Game.random.Next(3)) '速/遅
        }
        Return wave
    End Function

    Private Function Init_Horizontal_Wave() As HorizontalWave
        '海溝のぎりぎり上で止まるように、removal_bottomを設定する
        Dim wave As New HorizontalWave(Game) With {
            .Height = Game.Panel_Game.Height * 0.13,
            .Location = New Point(0, 0),
            .speed = Game.Rh(6 + Game.random.Next(4)), '速/遅
            .removal_bottom = Game.Panel_Game.Height - trench.Height - Game.Player.Height - Game.Rh(10)
        }
        Return wave
    End Function

    '毎度 Init -> Add するのが面倒なので、一つにまとめる
    Private Sub Spawn_Wave(_from As Integer, _to As Integer)
        Dim wave As Wave = Init_Wave(_from, _to)
        Game.Panel_Enemy.Controls.Add(wave)
    End Sub

    Private Sub Spawn_Horizontal_Wave()
        Dim wave As HorizontalWave = Init_Horizontal_Wave()
        Game.Panel_Enemy.Controls.Add(wave)
    End Sub


    '===========================================================
    'Override
    '===========================================================

    Dim _game_page As GamePage
    Overrides Property Game As GamePage
        Get
            Return _game_page
        End Get
        Set(value As GamePage)
            _game_page = value
        End Set
    End Property

    Dim _start_ftime As Integer?
    Overrides Property Start_Ftime As Integer?
        Get
            Return _start_ftime
        End Get
        Set(value As Integer?)
            _start_ftime = value
        End Set
    End Property

    Dim _cleared_at As Integer?
    Overrides Property Cleared_At As Integer?
        Get
            Return _cleared_at
        End Get
        Set(value As Integer?)
            _cleared_at = value
        End Set
    End Property
End Class


Class StageGameClear
    Inherits Stage

    '===========================================================
    'StageGameClear固有の処理
    '===========================================================

    Public Overrides Sub Start(_game_page As GamePage)
        MyBase.Start(_game_page)

        '見た目を設定
        Game.Panel_Game.BackColor = Color.FromArgb(255, 0, 0, 0)

        Dim crown As New PictureBox With {
            .Size = New Size(Game.Rw(75), Game.Rw(75)), '正方形
            .Image = My.Resources.crown,
            .SizeMode = PictureBoxSizeMode.StretchImage
        }
        Dim label As New Label With {
            .Text = "Thank you for playing!",
            .Font = New Font("MS UI Gothic", 20),
            .ForeColor = Color.White,
            .Size = New Size(Game.Rw(700), Game.Rh(100)),
            .TextAlign = ContentAlignment.MiddleCenter
        }
        '中央寄せ
        crown.Left = Game.Panel_Game.Width / 2 - crown.Width / 2
        label.Left = Game.Panel_Game.Width / 2 - label.ClientSize.Width / 2

        '配置決め
        crown.Top = Game.Rh(300)
        label.Top = crown.Bottom + Game.Rh(30)

        Game.Panel_Game.Controls.AddRange({crown, label})
        crown.BringToFront()
        label.BringToFront()
        Game.Player.BringToFront()

        'GameBGMを止める
        Game.form.game_bgm_player.Stop()
    End Sub

    Public Overrides Sub On_F_Update()
        If Ftime > 400 Then
            Game.form.thank_you_for_playing = True
            Game.form.Open_Top_Page()
        End If
    End Sub


    '===========================================================
    'Override
    '===========================================================

    Dim _game_page As GamePage
    Overrides Property Game As GamePage
        Get
            Return _game_page
        End Get
        Set(value As GamePage)
            _game_page = value
        End Set
    End Property

    Dim _start_ftime As Integer?
    Overrides Property Start_Ftime As Integer?
        Get
            Return _start_ftime
        End Get
        Set(value As Integer?)
            _start_ftime = value
        End Set
    End Property

    Dim _cleared_at As Integer?
    Overrides Property Cleared_At As Integer?
        Get
            Return _cleared_at
        End Get
        Set(value As Integer?)
            _cleared_at = value
        End Set
    End Property
End Class