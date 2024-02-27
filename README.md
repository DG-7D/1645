# 1645

調布市民の歌「わが町調布」の防災行政無線バージョンを再生するだけのアプリケーションです。

実行すると、同ディレクトリの`wagamachichofu.mp3`を再生します。存在しない場合は自動的に[調布市公式サイト](https://www.city.chofu.lg.jp/documents/221/wagamachichofu_1.mp3)からダウンロードします。事前に`wagamachichofu.mp3`を配置しておくことで実録した音源など任意の音声を流せます。

### タスクスケジューラ登録

時報のように決まった時刻に鳴らすにはタスクスケジューラを使うことができます。以下を実行すれば毎日16時45分、または毎時45分に鳴らすよう登録することができます。

```powershell
# 毎日16時45分
schtasks /create /sc daily /tn 1645 /tr "'\path\to\1645.exe'" /st 16:45
# 毎時45分
schtasks /create /sc hourly /tn 1645 /tr "'\path\to\1645.exe'" /st 00:45
```

パスに空白を含む場合はシングルクオートで囲った外側をダブルクオートで囲みます(PowerShell, cmd共通)。