
import packageInfo from '../../auth_config.json';

export const environment = {
  production: true,
  BaseURL: 'https://ba-coordination-p3.eastus.cloudapp.com/fourpatient-frontend',
  apiUrl: 'https://ba-coordination-p3.eastus.cloudapp.com/fourpatient-webapi/api',
  auth: {
    domain: packageInfo.domain,
    clientId: packageInfo.clientId,
    redirectUri: window.location.origin,
  },
};
