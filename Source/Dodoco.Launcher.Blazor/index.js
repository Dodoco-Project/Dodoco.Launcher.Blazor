import { defineConfig, install } from "@twind/core";
import presetAutoprefix from "@twind/preset-autoprefix";
import presetTailwind from "@twind/preset-tailwind";
import * as colors from "@twind/preset-tailwind/colors";

let dodocoLaunchertheme = {
    colors: {
        "primary": colors.yellow[300],
        "secondary": "#393b40",
        "defaulttext": "#ffffff",
        "background": "#21213bcc"
    },
    blur: {
        "DEFAULT": "24px",
    },
    borderRadius: {
        DEFAULT: "0.5rem",
    },
    fontFamily: {
        "sans": ["\"Josefin Sans\""]
    },
    textShadow: {
        "sm": "0 0 2px var(--tw-shadow-color)",
        "md": "0 0 4px var(--tw-shadow-color)",
        "DEFAULT": "0 0 4px var(--tw-shadow-color)",
        "lg": "0 0 16px var(--tw-shadow-color)",
        "xl": "0 0 24px var(--tw-shadow-color)",
        "2xl": "0 0 48px var(--tw-shadow-color)",
    }
};

install(
    defineConfig({
        preflight: {
            "@import": ["url(\"../Font/Josefin_Sans/JosefinSans.css\")"],
            "*:not(input[type=\"text\"])": {
                "caret-color": "transparent"
            },
            "::-webkit-scrollbar": {
                "width": "10px",
            },
            "::-webkit-scrollbar-track": {
                "background": dodocoLaunchertheme.colors.background,
                "border-radius": dodocoLaunchertheme.borderRadius.DEFAULT
            },
            "::-webkit-scrollbar-thumb": {
                "background": "rgba(0, 0, 0, 0.2)",
                "border-radius": dodocoLaunchertheme.borderRadius.DEFAULT
            },
            "::-webkit-scrollbar-thumb:hover": {
                "background": dodocoLaunchertheme.colors.primary
            }
        },
        presets: [ presetAutoprefix(), presetTailwind() ],
        darkMode: "class",
        theme: {
            extend: dodocoLaunchertheme
        }
    })
);