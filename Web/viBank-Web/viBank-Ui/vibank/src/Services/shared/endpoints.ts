type Endpoint =
    'auth' |
    'register' |
    'roles' |
    'accounts' |
    'ATMs' |
    'transactions';

    export  const endpoints = {
        auth: 'api/auth/login',
        register: 'api/auth/register',
        refreshToken: 'api/auth/refresh-token',
        forgotPassword: 'api/auth/forgot-password',
        resetPassword: 'api/auth/reset-password',
        verifyResetPasswordToken: 'api/auth/verify-reset-token',
        roles: '/roles',
        accounts: '/accounts',
        checkBalance: '/accounts/balance',
        ATMs: '/ATMs/all',
        deposit: '/transactions/deposit',
        withdraw: '/transactions/withdraw',
        transfer: '/transactions/transfer',
    }