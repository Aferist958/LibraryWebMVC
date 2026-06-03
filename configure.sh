SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

cp "$SCRIPT_DIR/.env.example" "$SCRIPT_DIR/.env"

read -p "Press Enter to continue..."