/** @type {import('tailwindcss').Config} */
export default {
    content: [
        "./index.html",
        "./src/**/*.{js,ts,jsx,tsx}",
    ],
    theme: {
        extend: {
            colors: {
                passionBlack: 'var(--passion-black)',
                passionRed: 'var(--passion-red)',
                gold: 'var(--gold)',
                softGray: 'var(--soft-gray)',
            },
            fontFamily: {
                serif: ['Playfair Display', 'serif'],
                sans: ['Inter', 'sans-serif'],
            }
        },
    },
    plugins: [],
}
