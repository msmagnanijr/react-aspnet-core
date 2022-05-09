### Enforce HTTPS in ASP.NET Core

https://github.com/dotnet/aspnetcore/issues/32361
https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-6.0&tabs=visual-studio#ssl-linux

```
dnf list installed nss-tools >/dev/null 2>&1 ||
  (echo "Installing dependencies." && \
  sudo dnf install -y nss-tools)

echo "Exporting developer certificate."
DEV_CERT="$HOME/aspnet-$USER.pem"
dotnet dev-certs https -ep "$DEV_CERT" --format PEM

CERT_DB=$(echo "$HOME/.mozilla/firefox/*.default-release")
[ -d "$CERT_DB" ] && echo "Adding certificate to Firefox default profile certificates." && \
  certutil -d "$CERT_DB" -A -t "C,," -n localhost -i "$DEV_CERT"

CERT_DB="$HOME/.pki/nssdb"
[ -d "$CERT_DB" ] && echo "Adding certificate to Edge/Chrome certificates." && \
  certutil -d "$CERT_DB" -A -t "C,," -n localhost -i "$DEV_CERT"

echo "Adding certificate to System certificates."
sudo cp "$DEV_CERT" /etc/pki/tls/certs
sudo update-ca-trust

rm "$DEV_CERT"
```
