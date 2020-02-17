const state = {
    token: "",
    isAuthenticated: false
};

const getters = {
    getToken(state) {
        return state.token;
    },
    isAuthenticated(state) {
        return state.isAuthenticated;
    }
};

const mutations = {
    setIsAuthenticated(state, payload) {
        state.isAuthenticated = payload.isAuthenticated;
    },
    setToken(state, payload) {
        state.token = payload.token;
    },
};

const actions = {
    login: ({ commit }, payload) => {
        commit('setIsAuthenticated', payload);
        commit('setToken', payload);
    }
};

export default {
    state,
    getters,
    mutations,
    actions,
};
