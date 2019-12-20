const state = {
    isAuthenticated: false
};

const getters = {
    isAuthenticated() {
        return state.isAuthenticated;
    }
};

const mutations = {
    setIsAuthenticated(state, payload) {
        state.isAuthenticated = payload.isAuthenticated
    }
};

const actions = {
    login: ({ commit }, payload) => {
        commit('setIsAuthenticated', payload);
    }
};

export default {
    state,
    getters,
    mutations,
    actions,
};
