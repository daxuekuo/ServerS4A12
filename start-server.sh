#!/usr/bin/env bash
set -euo pipefail

ROOT="$(cd "$(dirname "$0")" && pwd)"

detect_rid() {
  local os arch
  os="$(uname -s)"
  arch="$(uname -m)"

  case "$os" in
    Darwin)
      case "$arch" in
        arm64) echo "osx-arm64" ;;
        x86_64) echo "osx-x64" ;;
        *) return 1 ;;
      esac
      ;;
    Linux)
      case "$arch" in
        x86_64) echo "linux-x64" ;;
        aarch64|arm64) echo "linux-arm64" ;;
        *) return 1 ;;
      esac
      ;;
    *)
      return 1
      ;;
  esac
}

pick_server() {
  local rid="$1"
  local published="$ROOT/dist/$rid/DfoServer"
  local dev_dll="$ROOT/Server/DfoServer/bin/Debug/DfoServer.dll"

  if [[ -x "$published" ]]; then
    echo "$published"
    return 0
  fi

  if [[ -f "$dev_dll" ]] && command -v dotnet >/dev/null 2>&1; then
    echo "dotnet|$dev_dll"
    return 0
  fi

  return 1
}

RID="$(detect_rid)" || {
  echo "Unsupported platform." >&2
  exit 1
}

TARGET="$(pick_server "$RID")" || {
  echo "Server binary not found." >&2
  echo "Build a self-contained package first:" >&2
  echo "  ./publish.sh" >&2
  echo "Developers can also use:" >&2
  echo "  dotnet build Server/DfoServer.sln -c Debug" >&2
  exit 1
}

if [[ "$TARGET" == dotnet\|* ]]; then
  DLL="${TARGET#dotnet|}"
  cd "$ROOT/Server/DfoServer/bin/Debug"
  exec dotnet "$DLL" "$@"
fi

cd "$ROOT/dist/$RID"
exec ./DfoServer "$@"
