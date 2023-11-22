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
    }
};

install(
    defineConfig({
        preflight: {
            "@import": "url(\"../Font/Josefin_Sans/JosefinSans.css\")",
            "*:not(input[type=\"text\"])": {
                "caret-color": "transparent"
            },
            "::-webkit-scrollbar": {
                "@apply": "w-2"
            },
            "::-webkit-scrollbar-track": {
                "@apply": "bg-transparent"
            },
            "::-webkit-scrollbar-thumb": {
                "@apply": "bg-defaulttext/10 rounded"
            },
            "::-webkit-scrollbar-thumb:hover": {
                "@apply": "bg-primary"
            }
        },
        presets: [ presetAutoprefix(), presetTailwind() ],
        darkMode: "class",
        theme: {
            extend: dodocoLaunchertheme
        }
    })
);