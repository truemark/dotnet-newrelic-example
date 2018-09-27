FROM microsoft/dotnet:2.1-sdk AS build-env

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY app1/*.csproj ./app1/
RUN dotnet restore app1/app1.csproj --no-cache

# Copy everything else and build
COPY app1/ ./app1/
RUN dotnet publish app1/app1.csproj -c Release -o ../out --framework netcoreapp2.1 --runtime linux-x64 --self-contained false

ADD https://download.newrelic.com/dot_net_agent/latest_release/newrelic-netcore20-agent_8.6.45.0_amd64.tar.gz /home/appuser/app/newrelic
#ADD newrelic-netcore20-agent_8.6.45.0_amd64.tar.gz /home/appuser/app/newrelic

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out/ .
EXPOSE 8080
HEALTHCHECK --interval=30s --timeout=30s --start-period=5s --retries=3 CMD curl --fail http://localhost:5000healthcheck || exit 1
ENV ASPNETCORE_URLS "http://*:5000"
ENV CORECLR_ENABLE_PROFILING=1
ENV CORECLR_PROFILER={36032161-FFC0-4B61-B559-F6C5D41BAE5A}
ENV CORECLR_NEWRELIC_HOME="/home/appuser/app/newrelic/newrelic-netcore20-agent"
ENV CORECLR_PROFILER_PATH="/home/appuser/app/newrelic/newrelic-netcore20-agent/libNewRelicProfiler.so"
ENV NEW_RELIC_LICENSE_KEY="XX"
ENV NEW_RELIC_APP_NAME="ExampleApp1"
ENTRYPOINT ["dotnet", "app1.dll"]
