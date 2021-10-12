
import packageInfo from '../../auth_config.json';

export const environment = {
  production: true,
  BaseURL: 'http://fourpatient-frontend.eastus.cloudapp.azure.com/',
  apiUrl: 'http://fourpatient-frontend.eastus.cloudapp.azure.com/api',
  auth: {
    domain: packageInfo.domain,
    clientId: packageInfo.clientId,
    redirectUri: window.location.origin,
  },
};
