'use strict';

customElements.define('compodoc-menu', class extends HTMLElement {
    constructor() {
        super();
        this.isNormalMode = this.getAttribute('mode') === 'normal';
    }

    connectedCallback() {
        this.render(this.isNormalMode);
    }

    render(isNormalMode) {
        let tp = lithtml.html(`
        <nav>
            <ul class="list">
                <li class="title">
                    <a href="index.html" data-type="index-link">mega-gyn-app documentation</a>
                </li>

                <li class="divider"></li>
                ${ isNormalMode ? `<div id="book-search-input" role="search"><input type="text" placeholder="Type to search"></div>` : '' }
                <li class="chapter">
                    <a data-type="chapter-link" href="index.html"><span class="icon ion-ios-home"></span>Getting started</a>
                    <ul class="links">
                        <li class="link">
                            <a href="overview.html" data-type="chapter-link">
                                <span class="icon ion-ios-keypad"></span>Overview
                            </a>
                        </li>
                        <li class="link">
                            <a href="index.html" data-type="chapter-link">
                                <span class="icon ion-ios-paper"></span>README
                            </a>
                        </li>
                                <li class="link">
                                    <a href="dependencies.html" data-type="chapter-link">
                                        <span class="icon ion-ios-list"></span>Dependencies
                                    </a>
                                </li>
                                <li class="link">
                                    <a href="properties.html" data-type="chapter-link">
                                        <span class="icon ion-ios-apps"></span>Properties
                                    </a>
                                </li>
                    </ul>
                </li>
                    <li class="chapter modules">
                        <a data-type="chapter-link" href="modules.html">
                            <div class="menu-toggler linked" data-bs-toggle="collapse" ${ isNormalMode ?
                                'data-bs-target="#modules-links"' : 'data-bs-target="#xs-modules-links"' }>
                                <span class="icon ion-ios-archive"></span>
                                <span class="link-name">Modules</span>
                                <span class="icon ion-ios-arrow-down"></span>
                            </div>
                        </a>
                        <ul class="links collapse " ${ isNormalMode ? 'id="modules-links"' : 'id="xs-modules-links"' }>
                            <li class="link">
                                <a href="modules/AppModule.html" data-type="entity-link" >AppModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-bs-toggle="collapse" ${ isNormalMode ?
                                            'data-bs-target="#components-links-module-AppModule-bd6ef8dc8ccbd28d5f43df408f4db8301336bcdd44ab5fc1e7d51bbb45843cf13582f55dc6e3a03561fec9a05c1ce7b737cb42dbb5a1a2f243589d9891698a9a"' : 'data-bs-target="#xs-components-links-module-AppModule-bd6ef8dc8ccbd28d5f43df408f4db8301336bcdd44ab5fc1e7d51bbb45843cf13582f55dc6e3a03561fec9a05c1ce7b737cb42dbb5a1a2f243589d9891698a9a"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-AppModule-bd6ef8dc8ccbd28d5f43df408f4db8301336bcdd44ab5fc1e7d51bbb45843cf13582f55dc6e3a03561fec9a05c1ce7b737cb42dbb5a1a2f243589d9891698a9a"' :
                                            'id="xs-components-links-module-AppModule-bd6ef8dc8ccbd28d5f43df408f4db8301336bcdd44ab5fc1e7d51bbb45843cf13582f55dc6e3a03561fec9a05c1ce7b737cb42dbb5a1a2f243589d9891698a9a"' }>
                                            <li class="link">
                                                <a href="components/AlunoComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >AlunoComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/AppComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >AppComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/ExercicioComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >ExercicioComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/FooterComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >FooterComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/HomeComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >HomeComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/NavComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >NavComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/NovoAlunoComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >NovoAlunoComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/TreinoComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >TreinoComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                                <li class="chapter inner">
                                    <div class="simple menu-toggler" data-bs-toggle="collapse" ${ isNormalMode ?
                                        'data-bs-target="#injectables-links-module-AppModule-bd6ef8dc8ccbd28d5f43df408f4db8301336bcdd44ab5fc1e7d51bbb45843cf13582f55dc6e3a03561fec9a05c1ce7b737cb42dbb5a1a2f243589d9891698a9a"' : 'data-bs-target="#xs-injectables-links-module-AppModule-bd6ef8dc8ccbd28d5f43df408f4db8301336bcdd44ab5fc1e7d51bbb45843cf13582f55dc6e3a03561fec9a05c1ce7b737cb42dbb5a1a2f243589d9891698a9a"' }>
                                        <span class="icon ion-md-arrow-round-down"></span>
                                        <span>Injectables</span>
                                        <span class="icon ion-ios-arrow-down"></span>
                                    </div>
                                    <ul class="links collapse" ${ isNormalMode ? 'id="injectables-links-module-AppModule-bd6ef8dc8ccbd28d5f43df408f4db8301336bcdd44ab5fc1e7d51bbb45843cf13582f55dc6e3a03561fec9a05c1ce7b737cb42dbb5a1a2f243589d9891698a9a"' :
                                        'id="xs-injectables-links-module-AppModule-bd6ef8dc8ccbd28d5f43df408f4db8301336bcdd44ab5fc1e7d51bbb45843cf13582f55dc6e3a03561fec9a05c1ce7b737cb42dbb5a1a2f243589d9891698a9a"' }>
                                        <li class="link">
                                            <a href="injectables/AlunoService.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >AlunoService</a>
                                        </li>
                                        <li class="link">
                                            <a href="injectables/ExercicioService.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >ExercicioService</a>
                                        </li>
                                        <li class="link">
                                            <a href="injectables/TreinoService.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >TreinoService</a>
                                        </li>
                                    </ul>
                                </li>
                            </li>
                            <li class="link">
                                <a href="modules/AppRoutingModule.html" data-type="entity-link" >AppRoutingModule</a>
                            </li>
                </ul>
                </li>
                        <li class="chapter">
                            <div class="simple menu-toggler" data-bs-toggle="collapse" ${ isNormalMode ? 'data-bs-target="#injectables-links"' :
                                'data-bs-target="#xs-injectables-links"' }>
                                <span class="icon ion-md-arrow-round-down"></span>
                                <span>Injectables</span>
                                <span class="icon ion-ios-arrow-down"></span>
                            </div>
                            <ul class="links collapse " ${ isNormalMode ? 'id="injectables-links"' : 'id="xs-injectables-links"' }>
                                <li class="link">
                                    <a href="injectables/AlunoService.html" data-type="entity-link" >AlunoService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/ExercicioService.html" data-type="entity-link" >ExercicioService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/TreinoService.html" data-type="entity-link" >TreinoService</a>
                                </li>
                            </ul>
                        </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-bs-toggle="collapse" ${ isNormalMode ? 'data-bs-target="#interfaces-links"' :
                            'data-bs-target="#xs-interfaces-links"' }>
                            <span class="icon ion-md-information-circle-outline"></span>
                            <span>Interfaces</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? ' id="interfaces-links"' : 'id="xs-interfaces-links"' }>
                            <li class="link">
                                <a href="interfaces/IAluno.html" data-type="entity-link" >IAluno</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/IExercicio.html" data-type="entity-link" >IExercicio</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/ITreino.html" data-type="entity-link" >ITreino</a>
                            </li>
                        </ul>
                    </li>
                        <li class="chapter">
                            <a data-type="chapter-link" href="routes.html"><span class="icon ion-ios-git-branch"></span>Routes</a>
                        </li>
                    <li class="chapter">
                        <a data-type="chapter-link" href="coverage.html"><span class="icon ion-ios-stats"></span>Documentation coverage</a>
                    </li>
                    <li class="divider"></li>
                    <li class="copyright">
                        Documentation generated using <a href="https://compodoc.app/" target="_blank" rel="noopener noreferrer">
                            <img data-src="images/compodoc-vectorise.png" class="img-responsive" data-type="compodoc-logo">
                        </a>
                    </li>
            </ul>
        </nav>
        `);
        this.innerHTML = tp.strings;
    }
});