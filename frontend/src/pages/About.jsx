import Navbar from '../components/Navbar';

const About = () => {
    return (
        <div className="min-h-screen bg-passionBlack">
            <Navbar />
            <div className="max-w-4xl mx-auto py-20 px-4 sm:px-6 lg:px-8">
                <div className="text-center mb-16">
                    <h1 className="text-5xl font-serif text-white mb-6 uppercase tracking-[0.3em]">La Esencia</h1>
                    <div className="w-24 h-px bg-gold mx-auto opacity-50"></div>
                </div>

                <div className="space-y-12 text-lg text-softGray leading-relaxed font-sans font-light tracking-wide">
                    <p className="first-letter:text-5xl first-letter:font-serif first-letter:text-gold first-letter:mr-3 first-letter:float-left">
                        Velvet & Ivory nació del deseo de redefinir la intimidad. Creemos que la pasión es una forma de arte, y cada pieza en nuestra colección es un testimonio de la belleza de la conexión humana.
                    </p>

                    <div className="bg-[#1A1A1A] p-10 border-l-4 border-passionRed shadow-2xl rounded-r-2xl">
                        <p className="italic text-white font-serif text-2xl tracking-wider">
                            "La elegancia no es hacerse notar, es ser recordado. La pasión es lo que la hace inolvidable."
                        </p>
                    </div>

                    <p>
                        Nuestras selecciones curadas son meticulosamente obtenidas de artesanos que comparten nuestro compromiso con la calidad, el lujo y la profunda exploración del placer. Te invitamos a perderte en las texturas de la seda, la calidez de los aceites y el encanto del encaje.
                    </p>

                    <div className="grid grid-cols-1 md:grid-cols-2 gap-8 py-10">
                        <div className="border border-gold/10 p-8 hover:border-gold/30 transition-all rounded-2xl hover:shadow-gold/5 hover:-translate-y-1">
                            <h3 className="text-gold uppercase tracking-widest text-sm font-bold mb-4">Discreción</h3>
                            <p className="text-sm opacity-70">Empaquetado privado, entrega elegante. Tus secretos están a salvo en nuestro abrazo de terciopelo.</p>
                        </div>
                        <div className="border border-gold/10 p-8 hover:border-gold/30 transition-all rounded-2xl hover:shadow-gold/5 hover:-translate-y-1">
                            <h3 className="text-gold uppercase tracking-widest text-sm font-bold mb-4">Calidad</h3>
                            <p className="text-sm opacity-70">Solo los materiales más finos tocan tu piel. No nos conformamos con nada menos que el lujo absoluto.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default About;
