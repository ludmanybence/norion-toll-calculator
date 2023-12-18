import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    host:true,
    proxy: {
      "http://localhost:8080": {
        target: "http://localhost:5168",
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/http:localhost:8080/, ""),
      },
    },
  },
});
