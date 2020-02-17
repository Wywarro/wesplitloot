module.exports = {
  outputDir: '../wesplitlootapi/ClientApp/dist',
  "transpileDependencies": [
    "vuetify"
  ],
  devServer: {
    proxy: 'http://localhost:61307',
  },
}