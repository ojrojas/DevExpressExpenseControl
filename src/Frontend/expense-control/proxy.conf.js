module.exports = {
  "/identity": {
    target:
      process.env["services__identityerp__https__0"] ||
      process.env["services__identityerp__http__0"],
    secure: process.env["NODE_ENV"] !== "development",
    pathRewrite: {
      "^/identity": ""
    },
    changeOrigin: true,
    logLevel: "debug"
  },
  "/expensecontrolapi": {
    target:
      process.env["services__expensecontrolapi__https__0"] ||
      process.env["services__expensecontrolapi__http__0"],
    secure: process.env["NODE_ENV"] !== "development",
    pathRewrite: {
      "^/expensecontrolapi": ""
    },
    changeOrigin: true,
    logLevel: "debug"
  },
  "/notificationsapi": {
    target:
      process.env["services__notificationsapi__https__0"] ||
      process.env["services__notificationsapi__http__0"],
    secure: process.env["NODE_ENV"] !== "development",
    pathRewrite: {
      "^/notificationsapi": ""
    },
    changeOrigin: true,
    logLevel: "debug"
  },

  "/seq": {
    target:
      process.env["ConnectionStrings__seq"],
    secure: process.env["NODE_ENV"] !== "development",
    pathRewrite: {
      "^/seq": ""
    },
    changeOrigin: true,
    logLevel: "debug"
  },


};
console.debug(module.exports);
