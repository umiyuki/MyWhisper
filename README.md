# MyWhisper
WindowsでオーディオファイルをWhisper文字起こしできるアプリ

Windows向けにサクッと音声ファイルをWhisper文字起こしできるアプリが無かったので作りました。
コードはChatGPTに書いてもらいました。
アプリはboothで無料版、有料版を配布してます。→
https://umiyuki.booth.pm/items/4663311

使用しているMediaToolkitと言うライブラリが内部でFFMpegを使ってて、FFMpegはGPLだかLGPLライセンスらしいので、とりあえずこのコードもGPLでオープンソースにしました。

プロジェクトはVisualStudio2019で作成しています。
C#でWindows Formアプリケーションです。

# ビルド方法
VisualStudio2019で普通にビルドできるハズです。アイコンファイルはIcon8というフリーアイコンサイトからダウンロードしたものなので、リポジトリには上げてません。
こちらからダウンロードしてicoファイルに変換してください。→
<a target="_blank" href="https://icons8.com/icon/7LhMaNDFgoYK/create">Create</a> icon by <a target="_blank" href="https://icons8.com">Icons8</a>

別途Whisper.cppをビルドする必要があります。ビルドでできたmain.exeとwhisper.dllをアプリと同じフォルダに入れてください。
https://github.com/ggerganov/whisper.cpp

また、モデルファイルもダウンロードして同じフォルダに入れる必要があります。以下からggml-large.bin, ggml-medium.bin, ggml-small.bin, ggml-base.bin, ggml-tiny.binをDLします。
https://huggingface.co/datasets/ggerganov/whisper.cpp/tree/main

アプリの使用方法はこちらの販売ページに書いてあるものを参考にしてください。→https://umiyuki.booth.pm/items/4663311

# Credit
Whisper by OpenAI
https://github.com/openai/whisper

CTranslate2 by guillaumekln
https://github.com/OpenNMT/CTranslate2/

faster-whisper by guillaumekln
https://github.com/guillaumekln/faster-whisper

whisper-ctranslate2 by jordimas
https://github.com/Softcatala/whisper-ctranslate2
