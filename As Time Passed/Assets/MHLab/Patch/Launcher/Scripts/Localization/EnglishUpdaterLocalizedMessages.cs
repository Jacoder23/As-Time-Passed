using MHLab.Patch.Core.Client.Localization;

namespace MHLab.Patch.Launcher.Scripts.Localization
{
    public sealed class EnglishUpdaterLocalizedMessages : IUpdaterLocalizedMessages
    {
        public string UpdateDownloadingArchive => "Downloading patch (パッチのダウンロード) {0} to {1}...";
        public string UpdateDownloadedArchive => "Downloaded patch archive (ダウンロードしたパッチアーカイブ) {0}_{1}.";
        public string UpdateDecompressingArchive => "Decompressing patch (パッチを解凍する) {0} to {1}...";
        public string UpdateDecompressedArchive => "Decompressed patch (解凍されたパッチ) {0} to {1}.";
        public string UpdateUnchangedFile => "Unchanged file (変更のないファイル): {0}";
        public string UpdateProcessingNewFile => "Adding new file (新規ファイルの追加): {0}";
        public string UpdateProcessedNewFile => "Added new file (新規ファイルの追加): {0}";
        public string UpdateProcessingDeletedFile => "Deleting file (ファイルの削除): {0}";
        public string UpdateProcessedDeletedFile => "Deleted file (ファイルの削除): {0}";
        public string UpdateProcessingUpdatedFile => "Updating file (ファイルの修正): {0}";
        public string UpdateProcessedUpdatedFile => "Updated file (ファイル修正): {0}";
        public string UpdateProcessingChangedAttributesFile => "Fixing file attributes (ファイルの修復): {0}";
        public string UpdateProcessedChangedAttributesFile => "Fixed file attributes (修復されたファイル): {0}";
        public string NotAvailableNetwork => "Network is not available or connectivity is low/weak... Check your connection! サーバーが応答しません.... 数分待ってから再度お試しください。";
        public string NotAvailableServers => "Our servers are not responding... Wait some minutes and retry! サーバーが応答していません...。何分か待ってから再挑戦してください";
        public string LogsFileNotWritable => "Cannot write to the logs file. Probably the Launcher has not sufficient privileges. Continue anyway? ログファイルへの書き込みができません。続行しますか？";
        public string UpdateProcessCompleted => "Updating process completed successfully! Check game folder アップデート処理が正常に完了しました。フォルダの確認";
        public string UpdateProcessFailed => "Updating process failed! 更新処理に失敗しました。";
        public string UpdateRestartNeeded => "A restart is needed! 再起動が必要です。";
    }
}