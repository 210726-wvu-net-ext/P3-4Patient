
import packageInfo from '../../auth_config.json';

export const environment = {
  production: true,
  BaseURL: 'https://fourpatient-frontend.eastus.cloudapp.azure.com/',
  apiUrl: 'https://fourpatient-webapi.eastus.cloudapp.azure.com/api',
  auth: {
    domain: packageInfo.domain,
    clientId: packageInfo.clientId,
    redirectUri: window.location.origin,
  },
};
