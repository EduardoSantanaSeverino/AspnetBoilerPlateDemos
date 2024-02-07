{{- define "default.name" -}}
{{- if .Values.nameOverride -}}
{{- .Values.nameOverride | trunc 63 | trimSuffix "-" -}}
{{- else -}}
{{- printf "%s-%s" .Release.Name .Chart.Name | trunc 63 | trimSuffix "-" -}}
{{- end -}}
{{- end -}}

{{- define "default.domain" -}}
{{- if .Values.isReleaseDomain -}}
{{- printf "%s.%s" .Release.Name .Values.domain  -}}
{{- else -}}
{{- .Values.domain -}}
{{- end -}}
{{- end -}}

{{- define "imagePullSecret" }}
{{- with .Values.image }}
{{- printf "{\"auths\":{\"%s\":{\"username\":\"%s\",\"password\":\"%s\",\"auth\":\"%s\"}}}" .registry .credentials.username .credentials.password (printf "%s:%s" .credentials.username .credentials.password | b64enc) | b64enc }}
{{- end }}
{{- end }}
