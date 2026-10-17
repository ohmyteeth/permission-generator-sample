# Permission Source Generator サンプル

`[Permission("article", "read", "write")]` を付けるだけで、ASP.NET Core の認可ポリシー登録・権限名の定数・権限一覧を生成するサンプルです。

## 構成

- `PermissionGenerator/` : Source Generator 本体(netstandard2.0)
- `WebApp/` : 動作確認用の ASP.NET Core アプリ(net10.0)。認証はCookie認証で、デモ用の `/api/login` から好きな権限を付けてログインできる
- `PermissionSample.sln` : 上記2プロジェクトをまとめたソリューション

## 必要なもの

- .NET 10 SDK

## 動かし方

```bash
dotnet run --project WebApp --urls http://localhost:5080
```
