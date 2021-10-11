
import packageInfo from '../../auth_config.json';

export const environment = {
  production: true,
  apiUrl: 'http://localhost:32263/api',
  auth: {
    domain: packageInfo.domain,
    clientId: packageInfo.clientId,
    redirectUri: window.location.origin,
  },
};
