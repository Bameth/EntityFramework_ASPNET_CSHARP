module.exports = {
  content: [
    "./Pages/**/*.{cshtml,html}",
    "./Views/**/*.{cshtml,html}",
    "./wwwroot/**/*.{html,js}",
  ],
  theme: {
    extend: {
      animation: {
        gradientBG: "gradientBG 8s ease infinite",
      },
      keyframes: {
        gradientBG: {
          '0%': { 'background-position': '0% 50%' },
          '50%': { 'background-position': '100% 50%' },
          '100%': { 'background-position': '0% 50%' },
        },
      },
    },
  },
  plugins: [],
};
