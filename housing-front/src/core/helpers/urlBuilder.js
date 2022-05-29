export function urlBuilder(baseUrl) {
  const hasParameters = false;

  function addIfEnds(endsSymbol) {
    if (!baseUrl.endsWith(endsSymbol)) {
      baseUrl += endsSymbol;
    }
  }

  function withRoute(routeValue) {
    addIfEnds('/');
    baseUrl += routeValue ?? '';
    addIfEnds('/');
  }

  function withParameter(name, value) {
    if (!name || !value)
      return;

    if (!hasParameters) {
      addIfEnds('?');
    }

    baseUrl += name + '=' + value;
  }

  function build() {
    return baseUrl;
  }

  return {
    withRoute,
    withParameter,
    build
  };
}
