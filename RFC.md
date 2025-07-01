# Lendas Folclóricas

- **Título do Projeto**: [Lendas Folclóricas].
- **Nome do Estudante**: [Gustavo Alchini].
- **Curso**: Engenharia de Software.
- **Data de Entrega**: [30/06/2025].
## Resumo  

Este documento apresenta a proposta de um jogo 2D RPG educativo com perspectiva top-down, desenvolvido em Unity (C#), que combina elementos de horror psicológico e preservação cultural ao explorar criaturas do folclore brasileiro. A experiência busca equilibrar tensão narrativa com aprendizado, por meio de mecânicas como corrupção progressiva do mundo, quebras de quarta parede e diálogos com NPCs informativos.

O MVP do projeto prevê:

-1 área (floresta) com exploração livre.

-1 batalha contra criatura folclórica.

-Códice desbloqueáveil com informações reais apó a batalha.

-Arte em pixel art sombria com paleta terrosa.

-Design sonoro atmosférico para reforçar o horror psicológico.

O projeto visa estimular o interesse pelo folclore nacional em um formato interativo e engajador, ao mesmo tempo em que apresenta desafios técnicos relevantes para a formação em Engenharia de Software.

---

## 1. Introdução  

O folclore brasileiro é um patrimônio cultural rico e diverso, mas subutilizado em mídias interativas. Enquanto outras culturas exploram extensivamente seus mitos em jogos, filmes e livros, o Brasil carece de produções que apresentem suas lendas de forma inovadora e atraente para o público jovem.

Este projeto busca preencher essa lacuna por meio do desenvolvimento de um jogo 2D RPG educativo com estética sombria, mecânicas narrativas inovadoras e conteúdo pedagógico incorporado à jogabilidade. A proposta alia princípios de game design e engenharia de software para entregar uma experiência envolvente e instrutiva. 

### Justificativa  

- **Relevância Cultural:** Promove a valorização e a preservação do folclore brasileiro em um meio popular entre jovens e adultos. 
- **Inovação em Jogos:** Combina horror psicológico e mecânicas narrativas que quebram a quarta parede com ensino indireto e recompensador. 
- **Desafio Técnico:** Permite aplicar conhecimentos de desenvolvimento de software, design de sistemas dinâmicos (como corrupção progressiva do mundo) e otimização para hardware modesto.
- **Acessibilidade:** Oferece uma experiência single-player offline, sem exigência de hardware de ponta ou conexão constante. 

### Objetivos  

**Objetivo Geral:** Desenvolver um jogo 2D RPG funcional e educativo que introduza jogadores ao folclore brasileiro, por meio de narrativa envolvente, exploração de áreas temáticas e interações educativas com NPCs.  

**Objetivos Específicos:**  

-Implementar ao menos 3 áreas exploráveis com ambientações distintas (floresta, cemitério, caverna).

-Criar e animar ao menos 5 inimigos baseados em lendas brasileiras.

-Desenvolver um sistema de corrupção progressiva que transforme o mundo conforme o progresso do jogador.

-Integrar códices educativos com informações reais sobre as lendas, desbloqueados após eventos importantes.

-Realizar testes com jogadores para balancear o tom de horror e o conteúdo pedagógico.

---

## 2. Descrição do Projeto  

**Tema do Projeto:** Um jogo 2D top-down em estilo RPG, com estética sombria em pixel art, que combina elementos de horror psicológico e conteúdo educativo sobre o folclore brasileiro.  

### 2.1. **Narrativa Base:**

O jogador assume o papel de um jovem em busca de seus pais desaparecidos em regiões isoladas e sobrenaturais. Durante a jornada, enfrenta criaturas icônicas do folclore (como Saci, Cuca, Curupira, Lobisomem e Iara). A cada vitória, descobre que destruir esses seres contribui para o esquecimento da cultura nacional, gerando dilemas morais e afetando o mundo do jogo.

### 2.2. **Mecânicas Principais:**

-Exploração livre das áreas principais.

-Sistema de corrupção progressiva que transforma o ambiente de forma visual e mecânica conforme o jogador elimina criaturas.

-Quebra de quarta parede em momentos-chave para aumentar o horror psicológico e envolver o jogador diretamente.

-Diálogos ramificados com NPCs que explicam mitos e lendas de forma opcional.

-Desbloqueio de códices educativos contendo informações reais sobre cada criatura após batalhas.

<img src="https://imgur.com/x3tPbxF.png" alt="Diagrama de Gameplay" width="600"/>


### 2.3. **Objetivo Educativo:**

-Ensinar sobre o folclore brasileiro sem recorrer a recursos expositivos forçados ou "didáticos demais".

-Permitir ao jogador escolher o quanto deseja se aprofundar nos aspectos culturais por meio de diálogos e códices.

-Gerar reflexão sobre preservação cultural e responsabilidade individual/coletiva.

### 2.4. **Problemas a Resolver:**

-Equilibrar horror psicológico com conteúdo educativo sem diluir nenhum dos objetivos.

-Manter o jogo acessível mesmo em hardware mais modesto.

-Garantir uma narrativa envolvente, com consequências perceptíveis para decisões do jogador.

-Oferecer UX intuitiva que não sobrecarregue o jogador com textos, mantendo o ritmo da exploração e do combate.

### 2.5. **Limitações Conhecidas:**

-Escopo limitado a 3 áreas e 5 criaturas principais para garantir viabilidade no prazo de TCC.

-Sem dublagem de voz, para manter baixo o custo de produção.

-Arte e animações em pixel art com resolução reduzida para balancear estética e tempo de produção.

-Não abrangerá todas as lendas brasileiras; foco em um recorte selecionado e representativo.

---

## 3. Especificação Técnica  

Descrição detalhada da proposta, incluindo requisitos de software, arquitetura, protocolos, algoritmos, procedimentos, formatos de dados e ferramentas previstas para o desenvolvimento do jogo.

### 3.1. Requisitos de Software  

- **Engine de Desenvolvimento:** Unity (C#).
- **Linguagem:** C# (MonoBehaviour, ScriptableObjects, Coroutines).
- **Plataformas-alvo:** PC (Windows).  
- **Requisitos Mínimos:**  
 - CPU: Intel i3 6100 ou equivalente.
 - GPU: GeForce MX250 ou superior.
 - RAM: 8 GB.
 - Sistema Operacional: Windows 10 ou superior.

### 3.2. Considerações de Design  

- **Arte:**
  - Pixel art em resolução baixa (16x16 ou 32x32 sprites).
  - Paleta de cores terrosas e sombrias para reforçar atmosfera de horror.
  - Inspirações: Hyper Light Drifter, Darkest Dungeon (clima), Blasphemous (ambiente).
- **UI/UX:** 
  - Menus minimalistas com foco em legibilidade.
  - Tela de pause com curiosidades folclóricas desbloqueadas.
  - Diálogos ramificados com NPCs opcionais para manter ritmo da exploração.
- **Som:**
  - Design sonoro atmosférico com sons ambientes e efeitos para sustos leves.
  - Trilha adaptativa (volume/distorção conforme corrupção progride).
- **Sistema de Corrupção:**
  - Shader simples ou troca de paletas para ambientes mais sombrios conforme progresso.
  - Aumento de dificuldade de inimigos ou spawn rates.
  - Mudança de música e efeitos sonoros.
  - Eventos narrativos que alertam para as consequências das escolhas do jogador.

### 3.3. Arquitetura de Software 

- **Organização em Unity:**
  - Scenes separadas para cada área (Floresta, Cemitério, Caverna).
  - Prefabs para inimigos, NPCs, itens e triggers de corrupção.
  - ScriptableObjects para dados de criaturas e códices.
  - Sistema de Save/Load com PlayerPrefs ou arquivo JSON.

### 3.4. Stack Tecnológica  

- **Ferramentas de Desenvolvimento:**  
 - Unity (IDE).
 - Visual Studio / Rider para programação.
 - Aseprite para criação de pixel art.
 - Audacity para edição de áudio.
 - Trello ou Notion para gestão de tarefas e planejamento.
 - Git + GitHub para controle de versão.


### 3.5. Considerações de Segurança 

- **Proteção de Arquivos de Save:**
  - Criptografia leve (AES ou base64 com chave embutida) para evitar edição externa/trapaças.
  - Validação de integridade para impedir corrupção manual.

- **Privacidade:**
  - Nenhuma coleta de dados pessoais.
  - Jogo totalmente offline.

### 3.6. Considerações de Desempenho

  - Tilemaps e atlases para reduzir draw calls.
  - Limitação do número de inimigos simultâneos na tela para manter performance estável.


### 3.7. Formatos de Dados

 - Spritesheets: PNG com transparência.
 - Áudio: WAV/OGG para efeitos e trilha.
 - Saves: JSON ou PlayerPrefs com criptografia básica.

### ✅ 3.8. Restrições Técnicas

 - Sem multiplayer ou online features.
 - Sem dublagem de voz (apenas texto).
 - Resolução de sprites limitada para garantir viabilidade de produção.
 - Sistema de corrupção implementado em shader ou troca de tiles, sem uso de efeitos pesados.

---

## 4. Próximos Passos  

- **Fase 1 – Pré-Produção (Março a Junho 2025)**

  - Pesquisa aprofundada sobre folclore brasileiro para selecionar criaturas.
  - Definição completa da narrativa e roteiro de diálogos.
  - Criação de concept art para áreas e personagens.
  - Especificação detalhada de todas as mecânicas e sistema de corrupção.
  - Planejamento das tarefas em ferramenta de gestão (Trello/Notion).

- **Fase 2 – Produção Inicial (Junho a Julho 2025)**

  - Implementação do protótipo jogável com exploração básica.
  - Criação dos sprites iniciais em pixel art.
  - Implementação do sistema de movimento, colisão e HUD.
  - Desenvolvimento inicial de um inimigo com IA básica.
  - Testes internos para validar loop de gameplay.

- **Fase 3 – Produção Avançada (Julho 2025 a Setembro 2025)**

  - Implementação da maioria das áreas jogáveis.
  - Integração do sistema de corrupção progressiva.
  - Criação e integração dos 5 inimigos com comportamentos distintos.
  - Programação dos códices educativos e sistema de desbloqueio.
  - Criação de efeitos sonoros e trilha atmosférica.
  - Refinamento do design visual e animações.

- **Fase 4 – Testes e Ajustes (Setembro a Novemnbro 2025)**

  - Testes de jogabilidade com usuários-alvo (10–15 jogadores).
  - Balanceamento da dificuldade.
  - Ajustes de texto e conteúdo educativo para clareza e engajamento.
  - Otimização de desempenho.
  - Polimento de bugs e falhas.

- **Fase 5 – Finalização e Documentação (Novembro a Dezembro 2025)**

  - Geração de build final.
  - Elaboração de documentação técnica e manual do usuário.
  - Preparação de apresentação para banca.
  - Submissão dos materiais exigidos pelo curso.

- **Observação**
  -O cronograma acima é flexível e será ajustado conforme andamento real do projeto, porém serve como referência para o comprometimento com as entregas.

---

## 5. Referências  

CASCUDO, Luís da Câmara. Geografia dos Mitos Brasileiros. São Paulo: Global Editora, 2014.

SCHELL, Jesse. The Art of Game Design: A Book of Lenses. 2. ed. Boca Raton: CRC Press, 2014.

ADAMS, Ernest. Fundamentos do Game Design. 3. ed. São Paulo: Pearson, 2014.

SALEN, Katie; ZIMMERMAN, Eric. Rules of Play: Game Design Fundamentals. Cambridge: MIT Press, 2003.

UNITY TECHNOLOGIES. Unity Manual. Disponível em: https://docs.unity3d.com/Manual/index.html. Acesso em: 28 jun. 2025.

UNITY TECHNOLOGIES. Unity Learn. Disponível em: https://learn.unity.com/. Acesso em: 28 jun. 2025.

ASEPRITE. Aseprite Documentation. Disponível em: https://www.aseprite.org/docs/. Acesso em: 28 jun. 2025.

MICROSOFT. System.Security.Cryptography Documentation. Disponível em: https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography. Acesso em: 28 jun. 2025.

GITHUB DOCS. GitHub Documentation. Disponível em: https://docs.github.com/pt. Acesso em: 28 jun. 2025.

FREESOUND. Biblioteca de Efeitos Sonoros. Disponível em: https://freesound.org. Acesso em: 28 jun. 2025.

OPENGAMEART. Assets Gráficos Gratuitos. Disponível em: https://opengameart.org. Acesso em: 28 jun. 2025.

KENNEY. Kenney Assets. Disponível em: https://kenney.nl/assets. Acesso em: 28 jun. 2025.

HEART MACHINE. Hyper Light Drifter [Jogo eletrônico]. 2016.

RED HOOK STUDIOS. Darkest Dungeon [Jogo eletrônico]. 2016.

THE GAME KITCHEN. Blasphemous [Jogo eletrônico]. 2019.

TOBY FOX. Undertale [Jogo eletrônico]. 2015.

---


## 7. Avaliações de Professores  

**Considerações Professor/a:**  
[Espaço para feedback]  

**Considerações Professor/a:**  
[Espaço para feedback]  

**Considerações Professor/a:**  
[Espaço para feedback]  
